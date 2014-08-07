using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;
using System.Collections.Generic;
using System.Linq;


namespace RESTTests_RestSharp.Tests.Negative
{
    [TestFixture]
    public class ParameterTests  
    {
        [Test]
        public void ShouldReturn0ItemsWhenQParameterIsIncorrect()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("q", "1sAPUfRycSes");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ResponseContainer>(request);

            Assert.IsNull(response.Data.data.items, "Count did not match");
            
        }

        [Test]
        public void shouldReturnErrorWhenVersionRequestedIsIncorrect()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("v", "5");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ErrorResponseContainer>(request);

            Assert.AreEqual(403, response.Data.error.code, "Error code did not match");
            Assert.AreEqual("Version 5 is not supported.", response.Data.error.message, "Message did not match");
 
        }
    }
}
