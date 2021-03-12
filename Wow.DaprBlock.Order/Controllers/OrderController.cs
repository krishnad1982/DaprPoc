using System;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Wow.DaprBlock.Core;
using Wow.DaprBlock.Core.Models;
using Wow.DaprBlock.Order.Configurations;

namespace Wow.DaprBlock.Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private const string ContentType = "application/json";

        private readonly IHttpClientFactory _clientFactory;
        private readonly Setting _setting;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IHttpClientFactory clientFactory, IOptions<Setting> setting,
            ILogger<OrderController> logger)
        {
            _clientFactory = clientFactory;
            _setting = setting?.Value;
            _logger = logger;
        }

        [HttpPost("createorder")]
        public async Task<IActionResult> PublishOrder([FromBody] OrderDetails order)
        {
            _logger.LogInformation($"Order with order id {order.OrderId} received.");

            try
            {
                HttpResponseMessage response = await PostToDaprAsync(order);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation(
                        $"Order with order id {order.OrderId} published with status {response.StatusCode}.");
                }
                else
                {
                    _logger.LogError($"Something went wrong.");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }

        private async Task<HttpResponseMessage> PostToDaprAsync(OrderDetails order)
        {
            var client = _clientFactory.CreateClient();
            var url =
                $"{_setting.BaseUrl}:{_setting.DaprConfigurartion.DaprPort}/{_setting.DaprConfigurartion.DaprVersion}/{EndPoints.PublishToOrderTopic}";

            var serialized = JsonConvert.SerializeObject(order);
            var httpContent = new StringContent(serialized, Encoding.UTF8, ContentType);
            var response = await client.PostAsync(url, httpContent);

            return response;
        }
    }
}
