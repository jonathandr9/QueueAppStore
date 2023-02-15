using Microsoft.AspNetCore.Mvc;
using QueueAppStore.Domain.Models;

namespace QueueAppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PaymentWithCard")]
        public async Task PaymentWithCard(Card cardData)
        {
            

        }


    }
}