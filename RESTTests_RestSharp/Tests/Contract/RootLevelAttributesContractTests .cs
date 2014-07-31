using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;

namespace RESTTests_RestSharp.Tests.Contract
{
    [TestFixture]
    public class RootLevelAttributesContractTests 
    {
        [Test]
        public void ShouldHaveRootLevelAttributes()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("q", "sAPUfRycSes");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ResponseContainer>(request);

            Assert.NotNull(response.Data.apiVersion);
            Assert.NotNull(response.Data.data);
        }
    }
}
