using System.Collections.Generic;
using Web.FlickrSystem.Models.Weather;

namespace Web.FlickrSystem.Models.Flickr
{

    public class ImageSearchResponseDTO
    {
        public List<GalleryView> Gallery { get; set; }
        public List<MapMarker> MapMarkers { get; set; }
        public OpenWeatherMapResponseDTO Weather { get; set; }
    }
}
