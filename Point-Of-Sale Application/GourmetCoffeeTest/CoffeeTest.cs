using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GourmetCoffee;

namespace GourmetCoffeeTest
{
    [TestClass]
    public class CoffeeTest
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

        // Creates new Coffee object using the instance variables as properties.
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

        /// <summary>
        /// This method tests the properties of the Coffee class.
        /// </summary>
        [TestMethod]
        public void TestProperties()
        {
            Assert.IsTrue(coffee.Code.Equals(code));
            Assert.IsTrue(coffee.Description.Equals(description));
            Assert.IsTrue(coffee.Price.Equals(price));
            Assert.IsTrue(coffee.Origin.Equals(origin));
            Assert.IsTrue(coffee.Roast.Equals(roast));
            Assert.IsTrue(coffee.Flavor.Equals(flavor));
            Assert.IsTrue(coffee.Aroma.Equals(aroma));
            Assert.IsTrue(coffee.Acidity.Equals(acidity));
            Assert.IsTrue(coffee.Body.Equals(body));
        }

        /// <summary>
        /// This method tests the ToString() method of the Coffee class.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            Assert.IsTrue(coffee.ToString().Equals(code + "_" + description + "_" + price + "_" + origin + "_" + roast + "_" + flavor + "_" + aroma + "_" + acidity + "_" + body));
        }
    }
}
