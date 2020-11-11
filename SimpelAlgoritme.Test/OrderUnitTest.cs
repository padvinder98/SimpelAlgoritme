using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using SimpelAlgoritme.ApplicationCore.Models;
using System.Collections.Generic;

namespace SimpelAlgoritme.Test
{
    [TestClass]
    public class OrderUnitTest
    {
        [TestMethod]
        public void Order_GiveMaximumPrice()
        {
            // Arrange
            Order order = new Order();

            Product productMin = new Product("Ei", 1D);
            Product productMax = new Product("Kaas", 3D);

            order.Products.Add(productMin);
            order.Products.Add(productMax);

            // Act
            double output = order.GiveMaximumPrice();

            // Assert
            output.Should().Be(productMax.Price);
        }

        [TestMethod]
        public void Order_GiveAveragePrice()
        {
            // Arrange
            Order order = new Order();

            Product productMin = new Product("Ei", 1D);
            Product productMax = new Product("Kaas", 3D);

            order.AddProductToOrder(productMin);
            order.AddProductToOrder(productMax);

            double expextedOutput = 2D;

            // Act
            double output = order.GiveAveragePrice();

            // Assert
            output.Should().Be(expextedOutput);
        }

        [TestMethod]
        public void Order_GetAllProducts()
        {
            // Arrange
            Order order = new Order();

            Product product1 = new Product("Ei", 1D);
            Product product2 = new Product("Kaas", 3D);
            Product product3 = new Product("Ham", 2D);

            order.AddProductToOrder(product1);
            order.AddProductToOrder(product2);
            order.AddProductToOrder(product3);

            // Act
            List<Product> output = order.GetAllProducts(2D);

            //Assert
            output.Should().Contain(product2);
            output.Should().Contain(product3);
        }

        [TestMethod]
        public void Order_SortProductsByPrice()
        {
            // Arrange
            Order order = new Order();
            Product newProduct1 = new Product("Brood", 1D);
            Product newProduct2 = new Product("Ei", 2D);
            Product newProduct3 = new Product("Kaas", 3D);
            order.AddProductToOrder(newProduct3);
            order.AddProductToOrder(newProduct1);
            order.AddProductToOrder(newProduct2);

            List<Product> expextedProducts = new List<Product> { new Product("Brood", 1D), new Product("Ei", 2D), new Product("Kaas", 3D) };

            // Act
            List<Product> newProducts = order.SortProductsByPrice();

            // Assert
            newProducts.Should().BeEquivalentTo(expextedProducts);
        }
    }
}
