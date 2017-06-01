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

        private RestClient client = new RestClient("https://maps.googleapis.com/maps/api/")
        {
           UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36"
        };

        public async Task<Place> PlaceSearch(string place)
        {
            var request = new RestRequest("place/textsearch/json", Method.GET);

            var parameters = new string[]
            {
                "record",
                "store",
                HttpUtility.UrlEncode(place.Trim()).Replace("%2b", "+")
            };

            request.AddParameter("query", string.Join("+", parameters).ToLower()); 
            request.AddParameter("key", apiKey);

            // Debug.WriteLine("https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + string.Join("+", parameters).ToLower() + "&key=" + apiKey);

            var response = await client.ExecuteTaskAsync(request);

            return JsonConvert.DeserializeObject<Place>(response.Content);
        }

        public async Task<Details> PlaceDetails(string placeId)
        {
            var request = new RestRequest("place/details/json", Method.GET);
            request.AddParameter("placeid", placeId);
            request.AddParameter("key", apiKey);

            // Debug.WriteLine("https://maps.googleapis.com/maps/api/place/details/json?placeid=" + placeId + "&key=" + apiKey);

            var response = await client.ExecuteTaskAsync(request);

            return JsonConvert.DeserializeObject<Details>(response.Content);
        }

        public string PlacePhotos(string photoreference, string maxwidth)
        {
            return string.Concat("https://maps.googleapis.com/maps/api/place/photo?maxwidth=" + maxwidth + "&photoreference=" + photoreference + "&key=" + apiKey);
        }
    }
}