using System;
using System.Collections.Generic;
using Wow.DaprBlock.Core.Models;


namespace Wow.DaprBlock.Order
{
    public static class OrderHelper
    {
        public static List<OrderDetails> CreateOrders(int numberOfOrders = 2)
        {
            var orders = new List<OrderDetails>();
            for (var i = 0; i < numberOfOrders; i++)
            {
                var order = new OrderDetails
                {
                    CustomerId = GetRandomId(1, 100),
                    OrderId = Guid.NewGuid(),
                    Price = GetRandomPrice(10, 500),
                    ProductId = GetRandomId(1000, 3000),
                    Qty = GetRandomId(1, 20),
                    Reference = Guid.NewGuid()
                };
                orders.Add(order);
            }

            return orders;
        }

        private static double GetRandomPrice(double minimum, double maximum)
        {
            var random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private static int GetRandomId(int minimum, int maximum)
        {
            var random = new Random();
            return random.Next() * (maximum + minimum) + minimum;
        }
    }
}
