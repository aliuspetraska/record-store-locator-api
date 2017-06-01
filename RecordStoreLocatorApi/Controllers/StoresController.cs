using Newtonsoft.Json;
using RecordStoreLocatorApi.Models;
using RecordStoreLocatorApi.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RecordStoreLocatorApi.Controllers
{
    public class StoresController : ApiController
    {
        private GooglePlaces googlePlaces;

        public StoresController()
        {
            this.googlePlaces = new GooglePlaces();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(string parameter)
        {
            var variable = DecodeBase64(parameter.Trim());

            var delimiters = new char[] { ' ', ',', '-', '&' };
            var words = variable.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            variable = string.Join("+", words).ToLower();

            if (!string.IsNullOrEmpty(variable))
            {
                var result = await googlePlaces.PlaceSearch(variable.Trim());

                if (string.IsNullOrEmpty(result.error_message) && result.results.Count > 0)
                {
                    var response = new List<Store>();

                    foreach (var store in result.results)
                    {
                        var details = await googlePlaces.PlaceDetails(store.place_id);

                        var photos = new List<string>();

                        if (store.photos != null && store.photos.Count > 0)
                        {
                            foreach (var photo in store.photos)
                            {
                                photos.Add(googlePlaces.PlacePhotos(photo.photo_reference, 256.ToString()));
                            }
                        }
                        else
                        {
                            photos.Add(@"http://www.schoolgistonline.com/wp-content/plugins/wp-ulike/admin/classes//img/no-thumbnail.png");
                        }

                        var vicinity = details.result.vicinity;

                        if (string.IsNullOrEmpty(vicinity))
                        {
                            vicinity = details.result.formatted_address;
                        }

                        response.Add(new Store
                        {
                            place_id = store.place_id,
                            name = store.name,
                            formatted_address = details.result.formatted_address,
                            vicinity = vicinity,
                            formatted_phone_number = details.result.formatted_phone_number,
                            international_phone_number = details.result.international_phone_number,
                            website = details.result.website,
                            rating = details.result.rating,
                            open_now = store.opening_hours.open_now,
                            closed_now = !store.opening_hours.open_now,
                            location = store.geometry.location,
                            photos = photos,
                            default_photo = photos[0]
                        });
                    }

                    return Ok(response);
                }
            }

            return NotFound();
        }

        private string DecodeBase64(string encodedString)
        {
            byte[] data = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(data);
        }
    }
}
