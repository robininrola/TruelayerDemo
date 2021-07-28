using RestSharp;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace TrueLayer.Utilities
{
    public static class HTTPMessageUtilites
    {
        
        public static string GetResponseObjectArray(this IRestResponse response, string responseObject)
        {
            JArray jArray = JArray.Parse(@response.Content);
            return jArray.FirstOrDefault()[responseObject].ToString();
        }

        public static string  GetResponseObject(this IRestResponse response, string responseObject)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();
        }


    }
}
