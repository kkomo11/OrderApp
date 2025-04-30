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
            // Arrange
            var cart = new Cart();
            cart.AddProduct(new Product("Keyboard", 100));
            var service = new OrderService();

            // Act
            var order = service.PlaceOrder(cart);

            // Assert
            Assert.Equal("Completed", order.Status);
            Assert.Single(order.Items);
        }

        [Fact]
        public void PlaceOrder_WithEmptyCart_ShouldThrowException()
        {
            // Arrange
            var emptyCart = new Cart();
            var service = new OrderService();

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
        public void TotalPrice_Calculation()
        {
            var service = new OrderService();

            var items = new List<Product>
            {
                new Product("A", 100),
                new Product("B", 150)
            };
            var order = new Order(items);

            var price = service.CalcPrice(order, "VIP");

            Assert.Equal(225, price);
        }
    }
}
