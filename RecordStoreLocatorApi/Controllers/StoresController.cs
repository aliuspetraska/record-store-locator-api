using RecordStoreLocatorApi.Services;
using System;
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

            if (!string.IsNullOrEmpty(variable))
            {
                var result = await googlePlaces.PlaceSearch(variable.Trim());

                if (string.IsNullOrEmpty(result.error_message) && result.results.Count > 0)
                {
                    return Ok(new { result = "WORKS!" });
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
