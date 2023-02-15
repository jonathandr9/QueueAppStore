using Microsoft.AspNetCore.Mvc;

namespace QueueAppStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ILogger<PaymentController> _logger;

        public ClientController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        //[HttpPost(Name = "PaymentWithCard")]
        //public async Task PaymentWithCard(Card cardData)
        //{


        //}
    }
}