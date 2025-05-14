using System.Collections.Generic;

namespace OrderApp
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotalPrice() => Product.Price * Quantity;

        public void AddQuantity(int amount)
        {
            Quantity += amount;
        }
    }
}
