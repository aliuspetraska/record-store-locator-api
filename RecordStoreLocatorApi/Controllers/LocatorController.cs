using RecordStoreLocatorApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecordStoreLocatorApi.Controllers
{
    public class LocatorController : ApiController
    {
        private GooglePlaces googlePlaces;

        public LocatorController()
        {
            this.googlePlaces = new GooglePlaces();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = new string[] {
                "asdfasdfasdf",
                "afasdfasdf"
            };

            return Ok(result);
        }
    }
}
