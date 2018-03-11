using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Google
{
    public class GoogleAddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
