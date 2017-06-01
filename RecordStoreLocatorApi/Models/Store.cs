using System.Collections.Generic;

namespace RecordStoreLocatorApi.Models
{
    public class Store
    {
        public string place_id { get; set; }
        public string name { get; set; }
        public string formatted_address { get; set; }
        public string vicinity { get; set; }
        public string formatted_phone_number { get; set; }
        public string international_phone_number { get; set; }
        public string website { get; set; }
        public double rating { get; set; }
        public bool open_now { get; set; }
        public bool closed_now { get; set; }
        public Location location { get; set; }
        public List<string> photos { get; set; }
        public string default_photo { get; set; }
    }
}
