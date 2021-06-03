using System.Threading.Tasks;
using Consumer.Api.External;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Api.Controllers
{
    /// <summary>
    /// Api for interaction with orders
    /// </summary>
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        /// <inheritdoc cref="OrderController"/>
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary> Returns order by id </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GeOrderById([FromRoute] long id)
        {
            var result = await _orderService.GetOrderById(id);

            return Ok(result);
        }
    }
}