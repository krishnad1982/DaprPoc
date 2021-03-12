using Microsoft.AspNetCore.Mvc;
using Dapr;
using Microsoft.Extensions.Logging;
using Wow.DaprBlock.Core.Models;

namespace Wow.DaprBlock.Dispatch.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
       private readonly ILogger<StateController> _logger;

        public StateController(ILogger<StateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{orderStatus}")]
        public ActionResult<OrderStatus> Get([FromState("statestore", "orderStatus")]
            StateEntry<OrderStatus> orderStatus)
        {
            if (orderStatus.Value == null)
            {
                _logger.LogInformation(
                    $"We could not find the state.");
                return NotFound();
            }

            _logger.LogInformation(
                $"State with order id {orderStatus.Value.OrderId} saved to redis.");
            return orderStatus.Value;
        }
    }
}
