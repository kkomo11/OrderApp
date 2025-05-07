using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_Should_ReturnCompletedOrder()
        {
            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            IOrderLogger orderLogger = new OrderLogger();

            // Arrange
            var cart = new Cart();
            cart.AddProduct(new Product("Keyboard", 100));
            var service = new OrderService(factory, orderLogger);

            // Act
            var order = service.PlaceOrder(cart);

            // Assert
            Assert.Equal("Completed", order.Status);
            Assert.Single(order.Items);
        }

        [Fact]
        public void PlaceOrder_WithEmptyCart_ShouldThrowException()
        {
            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            IOrderLogger orderLogger = new OrderLogger();

            // Arrange
            var emptyCart = new Cart();
            var service = new OrderService(factory, orderLogger);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.PlaceOrder(emptyCart));
        }

        [Fact]
        public void TotalPrice_Should_ReturnCorrectSum()
        {
            var items = new List<Product>
            {
                new Product("A", 100),
                new Product("B", 150)
            };
            var order = new Order(items);

            Assert.Equal(250, order.TotalPrice);
        }

        [Fact]
        public void Cancel_Should_SetStatusToCancelled()
        {
            var order = new Order(new List<Product> { new Product("A", 100) });

            order.Cancel();

            Assert.Equal("Cancelled", order.Status);
        }

        [Fact]
        public void CancelledOrder_CannotBeCompleted()
        {
            var order = new Order(new List<Product> { new Product("A", 100) });
            order.Cancel();

            Assert.Throws<InvalidOperationException>(() => order.CompleteOrder());
        }

        [Fact]
        public void CompletedOrder_CannotBeCancelled()
        {
            var order = new Order(new List<Product> { new Product("A", 100) });
            order.CompleteOrder();

            Assert.Throws<InvalidOperationException>(() => order.Cancel());
        }

        [Fact]
        public void Clear_Should_EmptyCart()
        {
            var cart = new Cart();
            cart.AddProduct(new Product("A", 100));
            cart.AddProduct(new Product("B", 100));

            cart.Clear();

            Assert.Empty(cart.GetItems());
        }

        [Fact]
        public void CalcPrice_Should_ApplyCorrectDiscount_ForEachPolicy()
        {
            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            IOrderLogger orderLogger = new OrderLogger();

            var service = new OrderService(factory, orderLogger);

            var items = new List<Product>
            {
                new Product("A", 100),
                new Product("B", 200)
            };
            var order = new Order(items);

            var price_vip = service.CalcPrice(order, "VIP");
            var price_emp = service.CalcPrice(order, "EMPLOYEE");
            var price_season = service.CalcPrice(order, "SEASONAL");

            Assert.Equal(270, price_vip);
            Assert.Equal(240, price_emp);
            Assert.Equal(255, price_season);
        }

        [Fact]
        public void GetPolicy_WithUnknownType_ShouldReturnDefaultPolicy()
        {
            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            var policy =  factory.GetPolicy("UNKNOWN");
            Assert.Equal((new NoDiscountPolicy()).GetType(), policy.GetType());
        }

        [Fact]
        public void PlaceOrder_WithNullCart_ShouldThrowException()
        {
            IDiscountPolicyFactory factory = new DefaultDiscountPolicyFactory();
            IOrderLogger orderLogger = new OrderLogger();
            var service = new OrderService(factory, orderLogger);

            Assert.Throws<ArgumentException>(() => service.PlaceOrder(null));
        }

        [Fact]
        public void CompleteOrder_ShouldLog()
        {
            // Arrange
            var logger = new SpyOrderLogger();
            var factory = new DefaultDiscountPolicyFactory();
            var service = new OrderService(factory, logger);

            var cart = new Cart();
            cart.AddProduct(new Product("A", 100));

            // Act
            service.PlaceOrder(cart);

            // Assert
            Assert.True(logger.WasCalled);
        }
    }
}
