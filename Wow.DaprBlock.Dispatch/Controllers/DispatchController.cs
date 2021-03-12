using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dapr;
using Wow.DaprBlock.Core.Models;

namespace Wow.DaprBlock.Dispatch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DispatchController : ControllerBase
    {
        private readonly ILogger<DispatchController> _logger;

        public DispatchController(ILogger<DispatchController> logger)
        {
            _logger = logger;
        }

        [Topic("wowpublish", "order")]
        [HttpPost("processorder")]
        public IActionResult ProcessOrder([FromBody] OrderDetails order)
        {
            _logger.LogInformation(
                $"Order with id {order.OrderId} product {order.ProductId} qty {order.Qty} price {order.Price} and customer {order.CustomerId} has been processed.");
            //state management logic
            return Ok();
        }
    }
}
