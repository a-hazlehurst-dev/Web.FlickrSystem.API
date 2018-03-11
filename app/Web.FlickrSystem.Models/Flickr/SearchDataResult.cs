

using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Flickr
{
    public class SearchImageDataResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("server")]
        public string Server { get; set; }
        [JsonProperty("farm")]
        public int Farm { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("ispublic")]
        public int IsPublic { get; set; }
        [JsonProperty("isfriend")]
        public int IsFriend { get; set; }
        [JsonProperty("isfamily")]
        public int IsFamily { get; set; }
        [JsonProperty("tags")]
        public string Tags { get; set; }
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        [JsonProperty("longitude")]
        public string Longitute { get; set; }
        public int WhiteListCount { get; set; }
    }
}
