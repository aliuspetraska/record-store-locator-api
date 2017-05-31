using System.Collections.Generic;

namespace RecordStoreLocatorApi.Models
{
    public class OpeningHours
    {
        public bool open_now { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }

    public class AltId
    {
        public string place_id { get; set; }
        public string scope { get; set; }
    }

    public class PlaceResult
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public OpeningHours opening_hours { get; set; }
        public List<Photo> photos { get; set; }
        public string place_id { get; set; }
        public string scope { get; set; }
        public List<AltId> alt_ids { get; set; }
        public string reference { get; set; }
        public List<string> types { get; set; }
        public string vicinity { get; set; }
    }

    public class Place
    {
        public List<string> html_attributions { get; set; }
        public List<PlaceResult> results { get; set; }
        public string status { get; set; }
        public string error_message { get; set; }
    }
}