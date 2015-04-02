using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class GourmetCoffee
    {
        public Catalog catalog { set; get; }
        public Order currentOrder { set; get; }
        public Sales sales { set; get; }

        public GourmetCoffee()
        {
            catalog = new Catalog();
            currentOrder = new Order();
            sales = new Sales();
        }

        public void DisplayCatalog()
        {
            foreach (Product product in catalog)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public void DisplayProductInfo(string code)
        {
            Product product = catalog.GetProduct(code);

            if (product != null)
            {
                Console.WriteLine(product.ToString());
            }

            else
            {
                Console.WriteLine("Product does not exist in catalog.");
            }
        }

        public void DisplayOrder()
        {
            foreach (OrderItem orderItem in currentOrder)
            {
                Console.WriteLine(orderItem.ToString());
            }
        }

        public void AddModifyProduct(string code, int quantity)
        {
            Product product = catalog.GetProduct(code);

            if (product != null)
            {
                OrderItem orderItem = currentOrder.GetItem(product);

                if (orderItem != null)
                {
                    orderItem.Quantity = quantity;
                }

                else
                {
                    currentOrder.AddItem(new OrderItem() { Product = catalog.GetProduct(code), Quantity = quantity });
                }
            }

            else
            {
                Console.WriteLine("Product does not exist in catalog.");
            }
        }

        public void RemoveProduct(string code)
        {
            Product product = catalog.GetProduct(code);

            if (product != null)
            {
                OrderItem orderItem = currentOrder.GetItem(product);

                if (orderItem != null)
                {
                    currentOrder.RemoveItem(orderItem);
                }

                else
                {
                    Console.WriteLine("Product does not exist in current order.");
                }
            }

            else
            {
                Console.WriteLine("Product does not exist in catalog.");
            }
        }

        public void SaleOrder()
        {
            sales.AddOrder(currentOrder);
            currentOrder = new Order();

            Console.WriteLine("Current order registered.");
        }

        public void DisplayOrdersSold()
        {
            int orderNumber = 0;

            foreach (Order order in sales)
            {
                Console.WriteLine("Order Number: " + ++orderNumber);
                Console.WriteLine("---------------");

                foreach (OrderItem orderItem in order)
                {
                    Console.WriteLine(orderItem.ToString());
                }

                Console.WriteLine();
            }
        }

        public int DisplayNumberOfOrders(string code)
        {
            Product product = catalog.GetProduct(code);

            if (product != null)
            {
                int numberOfOrders = 0;

                foreach (Order order in sales)
                {
                    if (order.GetItem(product) != null)
                    {
                        numberOfOrders++;
                    }
                }

                Console.WriteLine("Number of Orders: " + numberOfOrders);

                return numberOfOrders;
            }

            else
            {
                Console.WriteLine("Product does not exist in catalog.");

                return 0;
            }
        }

        public int DisplayTotalQuantityOfProducts(string code)
        {
            int quantity = 0;

            foreach (Order order in sales)
            {
                OrderItem orderItem = order.GetItem(catalog.GetProduct(code));

                if (orderItem != null)
                {
                    quantity += orderItem.Quantity;
                }
            }

            Console.WriteLine("Total Quantity Sold: " + quantity);

            return quantity;
        }

        public void LoadCatalog()
        {
            catalog.AddProduct(new Coffee()
            {
                Code = "001",
                Description = "House Blend",
                Price = 1.99d,
                Origin = "Colombia",
                Roast = "Regular",
                Flavor = "Original",
                Aroma = "Strong",
                Acidity = "None",
                Body = "Full"
            });

            catalog.AddProduct(new Coffee()
            {
                Code = "002",
                Description = "French Vanilla Blend",
                Price = 2.99d,
                Origin = "Colombia",
                Roast = "Regular",
                Flavor = "French Vanilla",
                Aroma = "Strong",
                Acidity = "None",
                Body = "Full"
            });

            catalog.AddProduct(new Coffee()
            {
                Code = "003",
                Description = "Bold Blend",
                Price = 2.99d,
                Origin = "Colombia",
                Roast = "Dark",
                Flavor = "Original",
                Aroma = "Strong",
                Acidity = "None",
                Body = "Full"
            });

            catalog.AddProduct(new CoffeeBrewer()
            {
                Code = "004",
                Description = "Keurig Coffee Brewer",
                Price = 19.99d,
                Model = "Keurig 2.0",
                WaterSupply = "Pittsburgh City Water",
                NumberOfCups = 100
            });

            catalog.AddProduct(new Product()
            {
                Code = "005",
                Description = "Chocolate Chip Cookie",
                Price = 2.99d
            });

            catalog.AddProduct(new Product()
            {
                Code = "006",
                Description = "Double Fudge Brownie",
                Price = 3.99d
            });
        }
    }
}
