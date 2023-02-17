using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueAppStore.API.Models;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;


        public ClientController(
            ILogger<OrderController> logger,
            IClientService clientService,
            IMapper mapper)
        {
            _logger = logger;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<JsonResult> Login(LoginPost login)
        {
            var user = _mapper.Map<User>(login);

            var token = await _clientService.Login(user);

            return new JsonResult(new { token });

        }

        [HttpPost("Register")]
        public async Task<JsonResult> Register(RegisterPost register)
        {
            var client = _mapper.Map<Client>(register);
            var user = _mapper.Map<User>(register);

            var result = await _clientService.Register(client, user);

            return new JsonResult(result);
        }



    }
}