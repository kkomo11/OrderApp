using System;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AddProduct(new Product("Mouse", 50), 1);
            cart.AddProduct(new Product("Keyboard", 100), 1);

            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            IOrderLogger orderLogger = new OrderLogger();

            var service = new OrderService(factory, orderLogger);
            var order = service.PlaceOrder(cart);

            Console.WriteLine($"Order Status: {order.Status}");
        }
    }
}
