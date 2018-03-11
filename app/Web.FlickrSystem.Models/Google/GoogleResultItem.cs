
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Google
{
    public class GoogleResultItem
    {
        [JsonProperty("geometry")]
        public GoogleGeometry Geometry { get; set; }
        [JsonProperty("address_components")]
        public IEnumerable<GoogleAddressComponent> AddressComponents { get; set; }
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }
    }
}
