using Newtonsoft.Json;


namespace Web.FlickrSystem.Models.Google.Place
{
    public class GooglePlacesSuggestion
    {
        [JsonProperty("description")]
        public string Label { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }

    }
}
