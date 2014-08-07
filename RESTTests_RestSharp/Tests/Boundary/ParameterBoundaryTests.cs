using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;
using System.Linq;

namespace RESTTests_RestSharp.Tests.Boundary
{
    [TestFixture]
    public class ParameterBoundaryTests  
    {
        private IRestResponse<ResponseContainer> response;

        [Test]
        public void ShouldReturn0ItemsWhenMaxResultsIsSpecifiedAs0()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("max-results", "0");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            response = client.Execute<ResponseContainer>(request);

            Assert.IsNull(response.Data.data.items, "Items is not null");
        }

        [Test]
        public void shouldReturn50ItemsWhenMaxResultsIsSpecifiedAs50()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("max-results", "50");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            response = client.Execute<ResponseContainer>(request);

            Assert.AreEqual(50, response.Data.data.items.Count, "Items Count did not match");
        }

        [Test]
        public void ShouldReturnErrorWhenItemsRequestedis51()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("max-results", "51");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ErrorResponseContainer>(request);

            Assert.AreEqual(400, response.Data.error.code, "Error code did not match");
            Assert.AreEqual("Max-results value is too high. Only up to 50 results can be returned per query.",
                                    response.Data.error.message, "Message did not match");

        }

        [Test]
        public void ShouldReturnErrorWhenItemsRequestedIsMinus1()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("max-results", "-1");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ErrorResponseContainer>(request);

            Assert.AreEqual(400, response.Data.error.code, "Error code did not match");
            Assert.AreEqual("Invalid max-results", response.Data.error.message, "Message did not match");

        }
    }
}
