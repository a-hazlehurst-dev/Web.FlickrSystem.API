using System.Linq;
using System.Threading.Tasks;
using Web.FlickrSystem.Data.Interfaces.Context;
using Web.FlickrSystem.Data.Interfaces.Repositories;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Repositories
{
    public class LocationSearchCacheRepository : ILocationSearchCacheRepository
    {
        private readonly FlickrSystemContext _context;

        public LocationSearchCacheRepository(FlickrSystemContext context)
        {
            _context = context;
        }

        public async Task Create(LocationSearchCache locationSearchCache)
        {
             _context.LocationSearchCache.Add(locationSearchCache);

            await _context.SaveChangesAsync();
        }

        public async Task<LocationSearchCache> Get(string text)
        {
            return await Task.Run(() =>
            {
                return  _context.LocationSearchCache.SingleOrDefault(x => x.SearchText == "text");
            });
        }
    }
}
