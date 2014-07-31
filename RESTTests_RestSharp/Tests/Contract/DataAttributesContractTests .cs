using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;

namespace RESTTests_RestSharp.Tests.Contract
{
    [TestFixture]
    public class DataAttributesContractTests  
    {
        [Test]
        public void ShouldHaveDataAttributes()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("q", "sAPUfRycSes");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ResponseContainer>(request);

            Data data = response.Data.data;

            Assert.NotNull(data.updated);
            Assert.NotNull(data.totalItems);
            Assert.NotNull(data.startIndex);
            Assert.NotNull(data.itemsPerPage);

            Assert.AreEqual(1, data.items.Count, "Size of items did not match");


        }

    }
}
