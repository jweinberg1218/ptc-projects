using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class Product
    {
        public string Code { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }

        public Product()
        {
            Code = "";
            Description = "";
            Price = 0.0d;
        }

        public override bool Equals(Object obj)
        {
            Product product = (Product)obj;

            if (Code.Equals(product.Code))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Code + "_" + Description + "_" + Price;
        }
    }
}
