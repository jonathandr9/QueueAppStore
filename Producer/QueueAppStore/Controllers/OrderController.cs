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
        public async Task PaymentWithCard(OrderPost orderPost)
        {
            var order = _mapper.Map<Order>(orderPost);

            await _orderService.AddNew(order);  
        }


    }
}