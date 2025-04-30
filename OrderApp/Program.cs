using System;

namespace OrderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();
            cart.AddProduct(new Product("Mouse", 50));
            cart.AddProduct(new Product("Keyboard", 100));

            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();

            var service = new OrderService(factory);
            var order = service.PlaceOrder(cart);

            Console.WriteLine($"Order Status: {order.Status}");
        }
    }
}
