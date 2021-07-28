using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using TrueLayer.Base;
using TrueLayer.Utilities;

namespace TrueLayer.Steps
{

    [Binding, Scope(Feature = "GetSatellitePosition")]
    public class GetSatellitePositionSteps
    {


        private Settings _settings;

        public GetSatellitePositionSteps(Settings settings)
        {

            _settings = settings;
        }

        [Given(@"Perform Get operation for ""(.*)""")]
        public void GivenPerformGetOperationFor(string url)
        {
            _settings.Request = new RestRequest(url, Method.GET);

        }

              
        [Given(@"Perfom the operation added timestamp '(.*)'")]
        public void GivenPerfomTheOperationAddedTimestamp(int timeStamp)
        {
            _settings.Request.AddQueryParameter("timestamps", timeStamp.ToString());
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }



        [Then(@"I should see status code ok")]
        public void ThenIShouldSeeStatusCodeOk()
        {
            Assert.AreEqual(_settings.Response.StatusCode, HttpStatusCode.OK);
        }

        [Then(@"I should see the ""(.*)"" as ""(.*)""")] // To check the response and its value of given satellite positions
        public void ThenIShouldSeeTheAs(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObjectArray(key), Is.EqualTo(value), $"The {key} is not matching");
        }

        [Then(@"I should see the ""(.*)""daylight""")] //To check the response and its value of given satellite positions
        public void ThenIShouldSeeTheDaylight(string key, string value)
        {
            Assert.That(_settings.Response.GetResponseObjectArray(key), Is.EqualTo(value), $"The {key} is not matching");
        }
           
        [Given(@"Perfom the operation added double timestamp ""(.*)"", ""(.*)""")]
        public void GivenPerfomTheOperationAddedDoubleTimestamp(string p0, string p1)
        {
            _settings.Request.AddQueryParameter("timestamps", p0);
            _settings.Request.AddQueryParameter("timestamps", p1);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [Given(@"Perform the operation added malform timestamp ""(.*)""")]
        public void GivenPerformTheOperationAddedMalformTimestamp(string p0)
        {
            _settings.Request.AddQueryParameter("timestamps", p0);
            _settings.Response = _settings.RestClient.Execute(_settings.Request);
        }

        [Then(@"I should see status Bad Request")]
        public void ThenIShouldSeeStatusBadRequest()
        {
            Assert.AreEqual(_settings.Response.StatusCode, HttpStatusCode.BadRequest);
        }




    }
}
