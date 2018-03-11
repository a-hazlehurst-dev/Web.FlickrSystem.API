using System.Threading.Tasks;
using Web.FlickrSystem.Models.Google;

namespace Web.FlikrSystem.ApplicationServices.Interfaces
{
    public interface IGoogleSearchService
    {
        Task<GoogleGeoLocationSearchResult> GoogleGetGeoLocationsFromText(string text);
    }
}
