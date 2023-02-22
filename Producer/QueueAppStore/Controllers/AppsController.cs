using Microsoft.AspNetCore.Mvc;
using QueueAppStore.API.Models;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppsController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IAppService _appService;

        public AppsController(ILogger<OrderController> logger,
            IAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpGet(Name = "GetList")]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [ProducesResponseType(typeof(IEnumerable<App>), 200)]
        public async Task<IActionResult> GetList()
        {            
            try
            {
                var appsList = await _appService.GetAppsList();

                return Ok(appsList);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorModel()
                {
                    Code = 1,
                    Description = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ErrorModel()
                    {
                        Code = 500,
                        Description = ex.Message
                    });
            }
        }
    }
}
