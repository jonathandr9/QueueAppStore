using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QueueAppStore.API.Models;
using QueueAppStore.Domain.Models;
using QueueAppStore.Domain.Services;

namespace QueueAppStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger,
            IOrderService orderService,
            IMapper mapper)
        {
            _logger = logger;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost(Name = "PaymentWithCard")]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> PaymentWithCard(OrderPost orderPost)
        {
            try
            {
                var order = _mapper.Map<Order>(orderPost);

                await _orderService.AddNew(order);

                return Ok();
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

        
        [HttpGet(Name = "GetOrder")]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(ErrorModel), 500)]
        [ProducesResponseType(typeof(Order), 200)]
        public async Task<IActionResult> GetOrder(int idOrder)
        {

            try
            {
                var order = await _orderService.GetOrder(idOrder);

                return Ok(_mapper.Map<OrderGet>(order));
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