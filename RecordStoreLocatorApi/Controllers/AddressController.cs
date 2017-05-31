using RecordStoreLocatorApi.Models;
using RecordStoreLocatorApi.Services;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RecordStoreLocatorApi.Controllers
{
    public class AddressController : ApiController
    {
        private GoogleGeocoding googleGeocoding;

        public AddressController()
        {
            this.googleGeocoding = new GoogleGeocoding();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAsync(string parameter)
        {
            var variable = DecodeBase64(parameter.Trim());

            if (!string.IsNullOrEmpty(variable))
            {
                var parts = variable.Split('#');

                var location = new Location
                {
                    lat = StringToDouble(parts[0]),
                    lng = StringToDouble(parts[1])
                };

                var result = await googleGeocoding.Geocode(location);

                if (string.IsNullOrEmpty(result.error_message))
                {
                    return Ok(new { result = result.results[0].formatted_address });
                } 
            }

            return NotFound();
        }

        private string DecodeBase64(string encodedString)
        {
            byte[] data = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(data);
        }

        private double StringToDouble(string value)
        {
            return Convert.ToDouble(value.Replace('.', ','));
        }
    }
}
