using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp
{
    public class Order
    {
        public List<Product> Items { get; }
        public string Status { get; private set; }
        public decimal TotalPrice => Items.Sum(p => p.Price);

        public Order(List<Product> items)
        {
            Items = items;
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
