using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Web.FlickrSystem.Data.Interfaces.Context;
using Web.FlikrSystem.API.Filters;
using Web.FlikrSystem.ApplicationServices.Interfaces;
using Web.FlikrSystem.ApplicationServices.Services;

namespace Web.FlikrSystem.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<LoggingFilter>();
            services.AddScoped<IFlickrContext, FlickrSystemContext>();

            services.AddDbContext<FlickrSystemContext>(options => options.UseSqlServer(@"Server=.;Database=FlickrSystem;Trusted_Connection=True;"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
