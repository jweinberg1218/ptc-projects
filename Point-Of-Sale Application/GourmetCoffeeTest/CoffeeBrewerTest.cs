using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GourmetCoffee;

namespace GourmetCoffeeTest
{
    [TestClass]
    public class CoffeeBrewerTest
    {
        // Creates and initalizes instance variables.
        private static string code = "002";
        private static string description = "Best coffee brewer ever!";
        private static double price = 19.99d;
        private static string model = "Keurig";
        private static string waterSupply = "Pittsburgh City Water";
        private static int numberOfCups = 100;

        // Creates new Coffee object using the instance variables as properties.
        CoffeeBrewer coffeeBrewer = new CoffeeBrewer()
        {
            Code = code,
            Description = description,
            Price = price,
            Model = model,
            WaterSupply = waterSupply,
            NumberOfCups = numberOfCups
        };

        /// <summary>
        /// This method tests the properties of the CoffeeBrewer class.
        /// </summary>
        [TestMethod]
        public void TestProperties()
        {
            Assert.IsTrue(coffeeBrewer.Code.Equals(code));
            Assert.IsTrue(coffeeBrewer.Description.Equals(description));
            Assert.IsTrue(coffeeBrewer.Price.Equals(price));
            Assert.IsTrue(coffeeBrewer.Model.Equals(model));
            Assert.IsTrue(coffeeBrewer.WaterSupply.Equals(waterSupply));
            Assert.IsTrue(coffeeBrewer.NumberOfCups.Equals(numberOfCups));
        }

        /// <summary>
        /// This method tests the ToString() method of the CoffeeBrewer class.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Assert.IsTrue(coffeeBrewer.ToString().Equals(code + "_" + description + "_" + price + "_" + model + "_" + waterSupply + "_" + numberOfCups));
        }
    }
}
