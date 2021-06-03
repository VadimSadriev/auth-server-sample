using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ordering.Api.Application;
using Ordering.Api.Contracts;

namespace Ordering.Api.Controllers
{
    [Route("api/order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] long id)
        {
            var user = User;
            var order = await _orderService.GetOrderById(id);

            if (order == default)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderContract contract)
        {
            var id = await _orderService.CreateOrder(contract.Name);

            return Ok(id);
        }
    }
}