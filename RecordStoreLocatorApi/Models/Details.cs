using System.Collections.Generic;

namespace RecordStoreLocatorApi.Models
{
    public class Aspect
    {
        public int rating { get; set; }
        public string type { get; set; }
    }

    public class Review
    {
        public List<Aspect> aspects { get; set; }
        public string author_name { get; set; }
        public string author_url { get; set; }
        public string language { get; set; }
        public int rating { get; set; }
        public string text { get; set; }
        public object time { get; set; }
    }

    public class DetailsResult
    {
        public List<AddressComponent> address_components { get; set; }
        public string adr_address { get; set; }
        public string formatted_address { get; set; }
        public string formatted_phone_number { get; set; }
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string international_phone_number { get; set; }
        public string name { get; set; }
        public string place_id { get; set; }
        public string scope { get; set; }
        public List<AltId> alt_ids { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public List<Review> reviews { get; set; }
        public List<string> types { get; set; }
        public string url { get; set; }
        public string vicinity { get; set; }
        public string website { get; set; }
    }

    public class Details
    {
        public List<string> html_attributions { get; set; }
        public DetailsResult result { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}