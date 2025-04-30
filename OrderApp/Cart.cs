using System.Collections.Generic;

namespace OrderApp
{
    public class Cart
    {
        private List<Product> items = new List<Product>();

        public void AddProduct(Product product)
        {
            items.Add(product);
        }

        public List<Product> GetItems()
        {
            return items;
        }

        public void Clear()
        {
            items.Clear();
        }
    }
}
