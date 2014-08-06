using NUnit.Framework;
using RestSharp;
using RESTTests_RestSharp.Contract;
using System.Collections.Generic;
using System.Linq;


namespace RESTTests_RestSharp.Tests.Contract
{
    [TestFixture]
    public class LINQAssertionTests  
    {
        [Test]
        public void ShouldHaveDataAttributes()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("author", "krishnamohan777");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ResponseContainer>(request);
            Data data = response.Data.data;

            int allItems = data.items.Count;
            int uploadersCount = data.items.Where(i => i.uploader == "krishnamohan777").Count();

            Assert.AreEqual(allItems, uploadersCount, "Count did not match");
            
        }

        [Test]
        public void ShouldReturnItemsOrderedByRating()
        {
            var client = new RestClient("https://gdata.youtube.com/");

            var request = new RestRequest("feeds/api/videos", Method.GET);
            request.AddParameter("author", "krishnamohan777");
            request.AddParameter("orderby", "rating");
            request.AddParameter("v", "2");
            request.AddParameter("alt", "jsonc");

            var response = client.Execute<ResponseContainer>(request);
            Data data = response.Data.data;

            List<double> ratings = data.items.Where(i => i.rating > 0)
                                             .Select(i => i.rating).ToList();

            List<double> sortedRatings = data.items.Where(i => i.rating > 0)
                                                   .OrderByDescending(i => i.rating)
                                                   .Select(i => i.rating).ToList();

            Assert.AreEqual(sortedRatings, ratings, "Items are not sorted by rating");
 
        }
    }
}
