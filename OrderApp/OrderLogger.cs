using System;

namespace OrderApp
{
    public class OrderLogger : IOrderLogger
    {
        public void ShowOrderLog(Order order)
        {
            Console.WriteLine($"Order placed with {order.Items.Count} items, Status: {order.Status}");
        }
    }
}
