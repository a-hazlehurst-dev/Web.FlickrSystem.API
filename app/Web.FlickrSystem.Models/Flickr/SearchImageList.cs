
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Flickr
{
    public class SearchImageList
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("perpage")]
        public int PerPage { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
        [JsonProperty("photo")]
        public IEnumerable<SearchImageDataResult> Photos { get; set; }

    }
}
