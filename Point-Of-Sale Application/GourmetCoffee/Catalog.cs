using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class Catalog
    {
        private List<Product> products;

        public Catalog()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product>.Enumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public Product GetProduct(String code)
        {
            foreach (Product product in products)
            {
                if (product.Code.Equals(code))
                {
                    return product;
                }
            }

            return null;
        }

        public int GetNumberOfProducts()
        {
            return products.Count;
        }
    }
}
