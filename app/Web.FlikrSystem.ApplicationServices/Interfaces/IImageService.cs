
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.FlickrSystem.Models.Flickr;
using Web.FlickrSystem.Models.Google;
using Web.FlikrSystem.ApplicationServices.Services;

namespace Web.FlikrSystem.ApplicationServices.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<GalleryView>> GetGallery(IEnumerable<SearchImageDataResult> bases);
        Task<ImageSearchResponseDTO> GetImages(string text, string tags);
        Task<IEnumerable<SearchImageDataResult>> Search(string text, string tags, GoogleGeometry geoLocation);



    }
}
