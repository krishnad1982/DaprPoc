using System;
using System.Text.Json.Serialization;
using Wow.DaprBlock.Core.Enums;

namespace Wow.DaprBlock.Core.Models
{
    public class OrderStatus
    {
        public Guid OrderId { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderEvents OrderEvents { get; set; }
    }
}
