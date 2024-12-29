using System;
using System.Collections.Generic;

namespace MarketManagementSystem.Entities
{
    public class Cart
    {
        // Ürünün Id'si ile Adet bilgisini tutabiliriz
        private Dictionary<Product, int> _products;

        public Cart()
        {
            _products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Ürün nesnesi null olamaz.");

            if (quantity <= 0)
                throw new ArgumentException("Ürün adedi 0 veya negatif olamaz.");

            if (_products.ContainsKey(product))
                _products[product] += quantity;
            else
                _products.Add(product, quantity);
        }

        public Dictionary<Product, int> GetProducts()
        {
            return _products;
        }

        public decimal GetTotalAmount()
        {
            decimal total = 0;
            foreach (var item in _products)
            {
                total += item.Key.Price * item.Value;
            }
            return total;
        }
    }
}
