using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Google
{
    public class GoogleGeoLocationSearchResult
    {
        [JsonProperty("results")]
        public List<GoogleResultItem> Results { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
