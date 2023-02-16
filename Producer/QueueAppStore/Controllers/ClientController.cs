using Microsoft.AspNetCore.Mvc;
using QueueAppStore.API.Models;
using QueueAppStore.Domain.Models;

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

        [HttpPost("Login")]
        public async Task<Client> Login(LoginPost login)
        {
            return new Client();

        }

        [HttpPost("Register")]
        public async Task<Client> Register(RegisterPost register)
        {
            return new Client();
        }



    }
}