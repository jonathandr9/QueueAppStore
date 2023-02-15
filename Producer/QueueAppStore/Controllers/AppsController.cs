using Microsoft.AspNetCore.Mvc;

namespace QueueAppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppsController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public AppsController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        //[HttpPost(Name = "PaymentWithCard")]
        //public async Task PaymentWithCard(Card cardData)
        //{


        //}
    }
}
