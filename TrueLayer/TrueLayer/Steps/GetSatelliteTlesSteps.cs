using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TrueLayer.Base;
using TrueLayer.Utilities;

namespace TrueLayer.Steps
{
    [Binding, Scope(Feature = "GetSatelliteTles")]
    public class GetSatelliteTlesSteps
    {
        private Settings _settings;
        public GetSatelliteTlesSteps(Settings settings)
        {
            _settings = settings;

        }


        [Given(@"Perform Get operation for ""(.*)""")]
        public void GivenPerformGetOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);

        }


        [Then(@"I should see status code ok")]
        public void ThenIShouldSeeStatusCodeOk()
        {
            Assert.AreEqual(_settings.Response.StatusCode, HttpStatusCode.OK);
        }

        [Then(@"I should see the ""(.*)"" as ""(.*)""")] // To check the response and its value of given satellite tles 
        public void ThenIShouldSeeTheAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
        }

        [Then(@"I should see the ""(.*)""iss""")] //To check the response and its value of given satellite tles 
        public void ThenIShouldSeeTheDaylight(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
        }



        [Then(@"I should see status code NotFound")]
        public void ThenIShouldSeeStatusCodeNotFound()
        {
            Assert.AreEqual(_settings.Response.StatusCode, HttpStatusCode.NotFound);
        }

        [Then(@"I should see the error message ""(.*)""")]
        public void ThenIShouldSeeTheErrorMessage(string errorMessage)
        {
            Console.WriteLine(_settings.Response.Content);
            Assert.That(_settings.Response.Content, !Is.EqualTo(errorMessage) , $"{errorMessage} is not matching");
            
            
        }


    }
}
