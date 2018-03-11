using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Web.FlikrSystem.API.Filters
{
    public class LoggingFilter : ActionFilterAttribute
    {

        private readonly ILogger _logger;
        private DateTime startTime;
      

        public LoggingFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LoggingFilter");
        }
       

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            startTime = DateTime.Now;
            _logger.LogInformation("---- Start:   " +  context.HttpContext.Request.Path);
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var timePassed = DateTime.Now - startTime;
            _logger.LogInformation("---- End:   " +   context.HttpContext.Request.Path +" "+  context.HttpContext.Response.StatusCode +" " +timePassed.TotalMilliseconds );

            base.OnActionExecuted(context);
        }
    }
}
