
using Web.FlickrSystem.Models.Enum;

namespace Web.FlickrSystem.Models
{
    public class FlickrSearchDTO
    {
        public string ApiKey { get; set; }
        public FlickrSafeSearchEnum SafeSearch { get; set; }
        public FlickrPublicityFilterEnum PrivacyFilter { get; set; }
        public string Text { get; set; }
    }

}
