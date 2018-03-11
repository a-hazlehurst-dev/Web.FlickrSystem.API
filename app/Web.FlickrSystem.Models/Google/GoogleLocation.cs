using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Google
{

    public class GoogleLocation
    {
        [JsonProperty("lat")]
        public string Lat { get; set; }
        [JsonProperty("lng")]
        public string Lng { get; set; }
    }

}
