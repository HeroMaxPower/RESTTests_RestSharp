using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;
using System.Linq;

namespace RESTTests_RestSharp.Tests.Positive
{
    [TestFixture]
    public class AttributesAssertionTests  
    {
        private IRestResponse<ResponseContainer> response;

        [TestFixtureSetUp]
        public void Setup()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("q", "sAPUfRycSes");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            response = client.Execute<ResponseContainer>(request);

        }

        [Test]
        public void AssertDataAttributes()
        {
            Assert.AreEqual(1, response.Data.data.totalItems, "Size of items did not match");
            Assert.AreEqual(1, response.Data.data.startIndex, "Start Index did not match");
            Assert.AreEqual(25, response.Data.data.itemsPerPage, "Items Per Page did not match");
        }

        [Test]
        public void AssertItemAttributes()
        {
            Item item = response.Data.data.items.ElementAt(0);
            Assert.AreEqual("sAPUfRycSes", item.id, "id did not match");
            Assert.AreEqual("krishnamohan777", item.uploader, "Uploader did not match");
            Assert.AreEqual("Entertainment", item.category, "Category did not match");
            Assert.AreEqual("Maa thujhe salaam song on the stage by A R Rehman", item.title, "Title did not match");
            Assert.AreEqual(288, item.duration, "Duration did not match");
        }

        [Test]
        public void AssertRestrictionAttributes()
        {
            Restriction restriction = response.Data.data.items.ElementAt(0).restrictions.ElementAt(0);
            Assert.AreEqual("country", restriction.type, "Type did not match");
            Assert.AreEqual("deny", restriction.relationship, "Relationship did not match");
            Assert.AreEqual("DE", restriction.countries, "Countries did not match");
        }
    }
}
