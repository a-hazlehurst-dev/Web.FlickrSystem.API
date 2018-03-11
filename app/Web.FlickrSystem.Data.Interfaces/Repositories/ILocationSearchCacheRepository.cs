
using System.Threading.Tasks;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Interfaces.Repositories
{
    public interface ILocationSearchCacheRepository
    {

        Task<LocationSearchCache> Get(string text);
        Task Create(LocationSearchCache locationSearchCache);
    }
}
