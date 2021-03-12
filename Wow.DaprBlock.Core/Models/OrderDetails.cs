using System;

namespace Wow.DaprBlock.Core.Models
{
    public class OrderDetails
    {
        public Guid OrderId { get; set; }= Guid.NewGuid();
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
        public Guid Reference { get; set; }= Guid.NewGuid();
    }
}
