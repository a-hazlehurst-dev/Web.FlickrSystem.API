using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Google.Place
{
    public class GooglePlacesAutoCompleteResponse
    {
        [JsonProperty("predictions")]
        public IEnumerable<GooglePlacesSuggestion> Predictions { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
