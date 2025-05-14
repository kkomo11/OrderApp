using System;
using System.Collections.Generic;

namespace OrderApp
{
    public class OrderService
    {
        private readonly IDiscountPolicyFactory _factory;
        private readonly IOrderLogger _orderLogger;

        public OrderService(IDiscountPolicyFactory discountPolicyFactory, IOrderLogger orderLogger)
        {
            _factory = discountPolicyFactory;
            _orderLogger = orderLogger;
        }

        public Order PlaceOrder(Cart cart)
        {
            ValidateOrder(cart);
            Order order = CreateOrder(cart);
            order.CompleteOrder();
            _orderLogger.ShowOrderLog(order);
            SendEmail(order);

            return order;
        }

        private void ValidateOrder(Cart cart)
        {
            if (cart == null || cart.GetItems().Count == 0)
            {
                throw new ArgumentException("Cart is empty.");
            }
        }

        private Order CreateOrder(Cart cart)
        {
            return new Order(cart);
        }


        private void SendEmail(Order order)
        {
            Console.WriteLine($"Email sent: Order with {order.cartItems.Count} items is now '{order.Status}'");
        }

        public decimal CalcPrice(Order order, string ConsumerType)
        {
            var policy = _factory.GetPolicy(ConsumerType);
            return policy.ApplyDiscount(order.TotalPrice);
        }
    }
}
