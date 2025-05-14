using System.Collections.Generic;
using System.Linq;

namespace OrderApp
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {
            var existing = items.FirstOrDefault(i => i.Product.Name == product.Name);
            if (existing != null)
            {
                existing.AddQuantity(quantity);
            }
            else
            {
                items.Add(new CartItem(product, quantity));
            }
        }

        public decimal GetTotalPrice()
        {
            return items.Sum(item => item.GetTotalPrice());
        }

        public void Clear()
        {
            items.Clear();
        }

        // 필요한 경우 ReadOnly 형태로 제공
        public IReadOnlyCollection<CartItem> GetItems() => items.AsReadOnly();
    }
}
