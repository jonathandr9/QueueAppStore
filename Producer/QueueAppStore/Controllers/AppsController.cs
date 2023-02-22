using Microsoft.AspNetCore.Mvc;
using QueueAppStore.API.Models;
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
        public async Task<JsonResult> GetList()
        {            
            try
            {
                var appsList = await _appService.GetAppsList();

                return Json(appsList);

            }
            catch (Exception ex)
            {

                return new JsonResult(new ErrorModel
                {
                    Id = 1,
                    Description = ex.Message
                });
            }
        }
    }
}
