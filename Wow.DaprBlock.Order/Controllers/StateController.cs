using System;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wow.DaprBlock.Core;
using Wow.DaprBlock.Core.Models;

namespace Wow.DaprBlock.Order.Controllers
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

        [HttpPost("createstate")]
        public async Task<IActionResult> SaveState([FromBody] OrderStatus status)
        {
            _logger.LogInformation($"State with order id {status.OrderId} received.");

            try
            {
                status.OrderId = Guid.NewGuid();
                var daprClient = new DaprClientBuilder().Build();
                await daprClient.SaveStateAsync(EndPoints.StateMangement, status.OrderId.ToString(), status);
                _logger.LogInformation(
                    $"State with order id {status.OrderId} saved to redis.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(status.OrderId);
        }
    }
}
