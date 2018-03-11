using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.FlickrSystem.Models.Entities;

namespace Web.FlickrSystem.Data.Interfaces.Context
{
    public interface IFlickrContext 
    {
        DbSet<LocationSearchCache> LocationSearchCache { get; }
    }
}
