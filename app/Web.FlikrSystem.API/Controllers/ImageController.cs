using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.FlikrSystem.API.Filters;
using Web.FlikrSystem.ApplicationServices.Interfaces;

namespace Web.FlikrSystem.API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/image")]
    [ServiceFilter(typeof(LoggingFilter))]
    public class ImageController : Controller
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IImageService _imageService;

        public ImageController(ILogger<ImageController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet]
        [Route("{text}/")]
        [Route("{text}/{tags}")]
        public async Task<IActionResult> Get(string text, string tags ="")
        {
            var result = await _imageService.GetImages(text, tags);

            return Ok(result);
        }
    }
}