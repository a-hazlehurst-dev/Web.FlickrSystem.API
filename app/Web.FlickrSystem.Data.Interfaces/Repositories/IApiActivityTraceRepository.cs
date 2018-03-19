using System.Threading.Tasks;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Interfaces.Repositories
{
    public interface IApiActivityTraceRepository
    {

        Task Create(ApiActivityTrace apiActivityTrace);

    }
}
