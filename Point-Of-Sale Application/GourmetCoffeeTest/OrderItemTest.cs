using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GourmetCoffee;

namespace GourmetCoffeeTest
{
    /// <summary>
    /// This class tests the OrderItem class in GourmetCoffee.
    /// </summary>
    [TestClass]
    public class OrderItemTest
    {
        // Creates and initalizes instance variables.
        private static Product product = new Product()
        {
            Code = "001",
            Description = "Best product ever!",
            Price = 19.99d
        };

        private static int quantity = 1;

        // Creates new OrderItem object using the instance variables as properties.
        OrderItem orderItem = new OrderItem()
        {
            Product = product,
            Quantity = quantity
        };

        /// <summary>
        /// This method tests the properties of the OrderItem class.
        /// </summary>
        [TestMethod]
        public void TestProperties()
        {
            Assert.IsTrue(orderItem.Product.Equals(product));
            Assert.IsTrue(orderItem.Quantity.Equals(quantity));
        }

        /// <summary>
        /// This method tests the ToString() method of the OrderItem class.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Assert.IsTrue(orderItem.ToString().Equals(quantity + " " + product.Code + " " + product.Price));
        }
    }
}
