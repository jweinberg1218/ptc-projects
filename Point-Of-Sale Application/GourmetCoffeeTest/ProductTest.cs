using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GourmetCoffee;

namespace GourmetCoffeeTest
{
    /// <summary>
    /// This class tests the Product class in GourmetCoffee.
    /// </summary>
    [TestClass]
    public class ProductTest
    {
        // Creates and initalizes instance variables.
        private static string code = "001";
        private static string description = "Best product ever!";
        private static double price = 19.99d;

        // Creates new Product object using the instance variables as properties.
        Product product = new Product()
        {
            Code = code,
            Description = description,
            Price = price
        };

        /// <summary>
        /// This method tests the properties of the Product class.
        /// </summary>
        [TestMethod]
        public void TestProperties()
        {
            Assert.IsTrue(product.Code.Equals(code));
            Assert.IsTrue(product.Description.Equals(description));
            Assert.IsTrue(product.Price.Equals(price));
        }

        /// <summary>
        /// This method tests the Equals() method of the Product class.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            Assert.IsTrue(product.Equals(new Product { Code = code }));
        }

        /// <summary>
        /// This method tests the ToString() method of the Product class.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Assert.IsTrue(product.ToString().Equals(code + "_" + description + "_" + price));
        }
    }
}
