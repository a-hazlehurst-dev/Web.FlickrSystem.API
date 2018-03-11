
using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Google
{
    public class GoogleGeometry
    {
        [JsonProperty("location")]
        public GoogleLocation Location { get; set; }
    }
}
