using Microsoft.AspNetCore.Mvc;
using Saga.OrderService.Data;
using Saga.OrderService.Service;
using System.Threading.Tasks;

namespace Saga.OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            _ = await _orderService.CreateOrderAsync(order);

            return Accepted();
        }
    }
}
