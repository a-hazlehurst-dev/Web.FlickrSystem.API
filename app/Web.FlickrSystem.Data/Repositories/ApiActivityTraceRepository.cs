using System.Threading.Tasks;
using Web.FlickrSystem.Data.Interfaces.Context;
using Web.FlickrSystem.Data.Interfaces.Repositories;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Repositories
{
    public class ApiActivityTraceRepository : IApiActivityTraceRepository
    {
        private readonly FlickrSystemContext _flickrSystemContext;

        public ApiActivityTraceRepository(FlickrSystemContext flickrSystemContext)
        {
            _flickrSystemContext = flickrSystemContext;
        }

        public async Task Create(ApiActivityTrace apiActivityTrace)
        {
            _flickrSystemContext.ApiActivityTrace.Add(apiActivityTrace);

            await _flickrSystemContext.SaveChangesAsync();
        }
    }
}
