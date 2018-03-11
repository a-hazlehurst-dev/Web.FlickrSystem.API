
using Newtonsoft.Json;

namespace Web.FlickrSystem.Models.Flickr
{

    public class GalleryView
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("src")]
        public string Src { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("thumbnailCaption")]
        public string ThumbnailCaption { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty("thumbnailWidth")]
        public string ThumbnailWidth { get; set; }
        [JsonProperty("thumbnailHeight")]
        public string ThumbnailHeight { get; set; }
    }

}
