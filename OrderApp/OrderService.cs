using System;

namespace OrderApp
{
    public class OrderService
    {
        private readonly IDiscountPolicyFactory _factory;

        public OrderService(IDiscountPolicyFactory discountPolicyFactory)
        {
            _factory = discountPolicyFactory;
        }

        public Order PlaceOrder(Cart cart)
        {
            if (cart == null || cart.GetItems().Count == 0)
            {
                throw new ArgumentException("Cart is empty.");
            }

            Order order = new Order(cart.GetItems());
            order.CompleteOrder();

            SendEmail(order);

            return order;
        }

        private void SendEmail(Order order)
        {
            Console.WriteLine($"Email sent: Order with {order.Items.Count} items is now '{order.Status}'");
        }

        public decimal CalcPrice(Order order, string ConsumerType)
        {
            var policy = _factory.GetPolicy(ConsumerType);
            return policy.ApplyDiscount(order.TotalPrice);
        }
    }
}
