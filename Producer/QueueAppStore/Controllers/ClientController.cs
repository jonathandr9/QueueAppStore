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
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> Login(LoginPost login)
        {
            try
            {
                var user = _mapper.Map<User>(login);

                var token = await _clientService.Login(user);

                return Ok(new { token });
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

        [HttpPost("Register")]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> Register(RegisterPost register)
        {
            try
            {
                var client = _mapper.Map<Client>(register);
                var user = _mapper.Map<User>(register);

                var result = await _clientService.Register(client, user);

                return new JsonResult(result);
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