using Microsoft.EntityFrameworkCore;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Interfaces.Context
{
    public class FlickrSystemContext : DbContext, IFlickrContext
    {
        public FlickrSystemContext(DbContextOptions<FlickrSystemContext> options): base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LocationSearchCache>().Property(x=>x.Id).HasValueGenerator

        }

        public DbSet<LocationSearchCache> LocationSearchCache { get; set; }
    }
}
