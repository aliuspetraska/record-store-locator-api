using Newtonsoft.Json;
using RecordStoreLocatorApi.Models;
using RestSharp;
using System.Threading.Tasks;
using System.Web;

namespace RecordStoreLocatorApi.Services
{
    public class GooglePlaces
    {
        private string apiKey = @"AIzaSyBSTa0kYOBGxeoFZcvB5srrqdsDDkZHwho";

        private RestClient client = new RestClient("https://maps.googleapis.com/maps/api/");

        public async Task<Place> PlaceSearch(string place)
        {
            var request = new RestRequest("place/textsearch/json", Method.GET);

            var parameters = new string[]
            {
                "record",
                "store",
                HttpUtility.UrlEncode(place.Trim())
            };

            request.AddParameter("query", string.Join("+", parameters)); 
            request.AddParameter("key", apiKey);

            var response = await client.ExecuteTaskAsync(request);

            return JsonConvert.DeserializeObject<Place>(response.Content);
        }

        public string PlaceDetails(string place)
        {
            return string.Empty;
        }

        public string PlacePhotos(string place)
        {
            return string.Empty;
        }
    }
}