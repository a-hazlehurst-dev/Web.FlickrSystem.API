using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.FlikrSystem.API.Filters;
using Web.FlikrSystem.ApplicationServices.Interfaces;


namespace Web.FlikrSystem.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/place")]
    [ServiceFilter(typeof(LoggingFilter))]
    public class PlacesController : Controller
    {

        private readonly ILogger<ImageController> _logger;
        private readonly IPlaceService _placeService;

        public PlacesController(ILogger<ImageController> logger, IPlaceService placeService)
        {
            _logger = logger;
            _placeService = placeService;
        }

        [HttpGet]
        [Route("{text}")]
        public async Task<IActionResult> Get(string text)
        {
            try
            {
                var result = await _placeService.GetPlaces(text);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

    }
}
