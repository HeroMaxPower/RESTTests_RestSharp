using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;
using System.Linq;

namespace RESTTests_RestSharp.Tests.Contract
{
    [TestFixture]
    public class ItemAttributesContractTests  
    {
        IRestResponse<ResponseContainer> response;
        
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
        public void ShouldHaveItemAttributes()
        {

            Item item = response.Data.data.items.ElementAt(0);

            Assert.NotNull(item.id);
            Assert.NotNull(item.uploaded);
            Assert.NotNull(item.updated);
            Assert.NotNull(item.uploader);

            Assert.NotNull(item.category);
            Assert.NotNull(item.title);
            Assert.NotNull(item.description);

            Assert.NotNull(item.thumbnail);
            Assert.NotNull(item.player);
            Assert.NotNull(item.content);
            Assert.NotNull(item.duration);
            Assert.NotNull(item.rating);
            Assert.NotNull(item.likeCount);
            Assert.NotNull(item.ratingCount);
            Assert.NotNull(item.viewCount);
            Assert.NotNull(item.favoriteCount);
            Assert.NotNull(item.commentCount);
            Assert.NotNull(item.restrictions);
            Assert.NotNull(item.accessControl);

        }

        [Test]
        public void ShouldHaveRestrictionsAttributes()
        {
            Restriction restriction = response.Data.data.items.ElementAt(0).restrictions.ElementAt(0);

            Assert.NotNull(restriction.type);
            Assert.NotNull(restriction.relationship);
            Assert.NotNull(restriction.countries);
        }

        [Test]
        public void ShouldHaveAccessControlAttributes()
        {
            AccessControl accessControl = response.Data.data.items.ElementAt(0).accessControl;

            Assert.NotNull(accessControl.comment);
            Assert.NotNull(accessControl.commentVote);
            Assert.NotNull(accessControl.videoRespond);
            Assert.NotNull(accessControl.rate);
            Assert.NotNull(accessControl.embed);
            Assert.NotNull(accessControl.list);
            Assert.NotNull(accessControl.autoPlay);
            Assert.NotNull(accessControl.syndicate);
        }
    }
}
