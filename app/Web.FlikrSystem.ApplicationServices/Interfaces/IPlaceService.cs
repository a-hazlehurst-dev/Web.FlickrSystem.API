using System.Collections.Generic;using System.Threading.Tasks;
using Web.FlickrSystem.Models.Google.Place;

namespace Web.FlikrSystem.ApplicationServices.Interfaces
{
    public interface IPlaceService
    {

        Task<IEnumerable<string>> GetPlaces(string text);

    }
}
