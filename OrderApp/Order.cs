using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp
{
    public class Order
    {
        public List<CartItem> cartItems { get; }
        public string Status { get; private set; }
        public decimal TotalPrice => cartItems.Sum(p => p.Product.Price * p.Quantity);

        public Order(Cart cart)
        {
            this.cartItems = cart.GetItems().ToList();
            Status = "Pending";
        }

        public void CompleteOrder()
        {
            if (Status == "Cancelled")
                throw new InvalidOperationException("Cancelled orders cannot be completed.");

            Status = "Completed";
        }

        public void Cancel()
        {
            if (Status == "Completed")
                throw new InvalidOperationException("Completed orders cannot be cancelled.");

            Status = "Cancelled";
        }
    }
}
