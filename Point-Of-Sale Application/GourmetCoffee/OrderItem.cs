using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class OrderItem
    {
        public Product Product { set; get; }
        public int Quantity { set; get; }

        public OrderItem()
        {
            Product = null;
            Quantity = 0;
        }

        public override string ToString()
        {
            return Quantity + " " + Product.Code + " " + Product.Price;
        }
    }
}
