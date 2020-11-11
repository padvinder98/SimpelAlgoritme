using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpelAlgoritme.ApplicationCore.Models
{
    public class Order
    {
        public List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }

        public void AddProductToOrder(Product product)
        {
            Products.Add(product);
        }

        public double GiveMaximumPrice()
        {
            double highestPrice = 0;

            foreach (var product in Products)
            {
                if (product.Price > highestPrice)
                {
                    highestPrice = product.Price;
                }
            }

            return highestPrice;
        }

        public double GiveAveragePrice()
        {
            int itemsInOrderCount = 0;
            double totalValue = 0D;

            foreach (var product in Products)
            {
                itemsInOrderCount++;

                totalValue += product.Price;
            }

            return totalValue / itemsInOrderCount;
        }

        public List<Product> GetAllProducts(double minPrice)
        {
            List<Product> minPriceProducts = new List<Product>();

            foreach (var product in Products)
            {
                if (product.Price >= minPrice)
                {
                    minPriceProducts.Add(product);
                }
            }

            return minPriceProducts;
        }

        public List<Product> SortProductsByPrice()
        {
            List<Product> sortedProducts = new List<Product>();

            foreach (var product in Products.OrderBy(p => p.Price))
            {
                sortedProducts.Add(product);
            }

            return sortedProducts;
        }
    }
}
