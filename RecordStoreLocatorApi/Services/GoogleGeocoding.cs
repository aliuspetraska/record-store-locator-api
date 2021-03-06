﻿using Newtonsoft.Json;
using RecordStoreLocatorApi.Models;
using RestSharp;
using System.Threading.Tasks;

namespace RecordStoreLocatorApi.Services
{
    public class GoogleGeocoding
    {
        private string apiKey = @"AIzaSyBSTa0kYOBGxeoFZcvB5srrqdsDDkZHwho";

        public async Task<Geocode> Geocode(Location location)
        {
            var client = new RestClient("https://maps.googleapis.com/maps/api/")
            {
                UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36"
            };

            var request = new RestRequest("geocode/json", Method.GET);

            var parameters = new string[]
            {
                DuobleToString(location.lat),
                DuobleToString(location.lng)
            };

            request.AddParameter("latlng", string.Join(",", parameters));
            request.AddParameter("location_type", "APPROXIMATE");
            request.AddParameter("key", apiKey);

            var response = await client.ExecuteTaskAsync(request);

            return JsonConvert.DeserializeObject<Geocode>(response.Content);
        }

        private string DuobleToString(double value)
        {
            return value.ToString().Replace(',', '.');
        }
    }
}