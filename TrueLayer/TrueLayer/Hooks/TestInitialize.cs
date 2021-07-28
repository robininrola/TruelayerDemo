using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TrueLayer.Base;

namespace TrueLayer.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private Settings _settings;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extentReport;



        public TestInitialize(Settings settings, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            _settings = settings;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]

        public void TestSetup()
        {
            _settings.BaseUrl = new Uri("https://api.wheretheiss.at/v1/satellites/25544");
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }

        [BeforeScenario]
        public void Intialize()
        {
            //for creating Dynamic feature Name
            featureName = extentReport.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            //for creating Dynamic scenario Name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [BeforeTestRun] // intialize the report before test starts
        public static void InitializeReport()
        {
            string fileName = "TestReport.html";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDown()
        {
            extentReport.Flush();
        }

        [AfterStep] //For detailed reporting in Report which step is missed or not
        public void ReportingStepsInReport()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }

        }
    }

}

