

using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Flickr
{
    public class MapMarker
    {
        [JsonProperty("lat")]
        public decimal Lat { get; set; }
        [JsonProperty("lng")]
        public decimal Lng { get; set; }
    }
}
