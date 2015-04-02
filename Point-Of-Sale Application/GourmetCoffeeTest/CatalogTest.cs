using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GourmetCoffee;

namespace GourmetCoffeeTest
{
    /// <summary>
    /// This class tests the Catalog class in GourmetCoffee.
    /// </summary>
    [TestClass]
    public class CatalogTest
    {
        // Creates and initalizes instance variables.
        private static string code = "001";
        private static string description = "Best coffee ever!";
        private static double price = 19.99d;
        private static string origin = "Colombia";
        private static string roast = "Dark";
        private static string flavor = "Original";
        private static string aroma = "Strong";
        private static string acidity = "None";
        private static string body = "Full";

        // Creates new Product object using the instance variables as properties.
        Coffee coffee = new Coffee()
        {
            Code = code,
            Description = description,
            Price = price,
            Origin = origin,
            Roast = roast,
            Flavor = flavor,
            Aroma = aroma,
            Acidity = acidity,
            Body = body
        };

        // Creates new Catalog object.
        Catalog catalog = new Catalog();

        /// <summary>
        /// This method tests the AddProduct() method of the Catalog class.
        /// </summary>
        [TestMethod]
        public void TestAddProduct()
        {
            // Passes Product object to AddProduct() method.
            catalog.AddProduct(coffee);

            // Creates and initalizes instance variable.
            bool containsProduct = false;

            // Enumerates through each Product object in the Catalog class.
            foreach (Product prod in catalog)
            {
                //If a match is found, set boolean to true.
                if (coffee.Equals(prod))
                {
                    containsProduct = true;
                }
            }

            Assert.IsTrue(containsProduct);
        }

        /// <summary>
        /// This method tests the GetProduct() method of the Catalog class.
        /// </summary>
        [TestMethod]
        public void TestGetProduct()
        {
            // Passes Product object to AddProduct() method.
            catalog.AddProduct(coffee);

            // Creates new Product object using the GetProduct() method of the Catalog class.
            Product prod = catalog.GetProduct(code);

            Assert.IsTrue(coffee.Equals(prod));
        }
    }
}
