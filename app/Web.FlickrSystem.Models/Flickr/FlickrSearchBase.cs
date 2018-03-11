using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Flickr
{
    public class FlikrSearchBase
    {
        [JsonProperty("photos")]
        public SearchImageList Photos { get; set; }
        [JsonProperty("stat")]
        public string Stat { get; set; }
    }
}
