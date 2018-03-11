using System.Collections.Generic;

namespace Web.FlickrSystem.Models.Flickr
{

    public class ImageSearchResponseDTO
    {
        public List<GalleryView> Gallery { get; set; }
        public List<MapMarker> MapMarkers { get; set; }
    }
}
