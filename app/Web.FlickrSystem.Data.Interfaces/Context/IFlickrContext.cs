using Microsoft.EntityFrameworkCore;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Interfaces.Context
{
    public interface IFlickrContext 
    {
        DbSet<LocationSearchCache> LocationSearchCache { get; set; }
        DbSet<ApiActivityTrace> ApiActivityTrace { get; set; }
    }
}
