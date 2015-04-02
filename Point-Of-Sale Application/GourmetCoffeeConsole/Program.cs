using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GourmetCoffee;

namespace GourmetCoffeeConsole
{
    class Program
    {
        private static int choice, quantity;
        private static string code;

        static void Main(string[] args)
        {
            GourmetCoffee.GourmetCoffee gourmetCoffee = new GourmetCoffee.GourmetCoffee();

            gourmetCoffee.LoadCatalog();

            Console.WriteLine("[0] Quit");
            Console.WriteLine("[1] Display catalog");
            Console.WriteLine("[2] Display product");
            Console.WriteLine("[3] Display current order");
            Console.WriteLine("[4] Add|modify product to|in current order");
            Console.WriteLine("[5] Remove product from current order");
            Console.WriteLine("[6] Register sale of current order");
            Console.WriteLine("[7] Display sales");
            Console.WriteLine("[8] Display number of orders with a specific product");
            Console.WriteLine("[9] Display the total quantity sold for each product");

            while (true)
            {
                Console.Write("choice>");

                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Environment.Exit(0);

                        break;

                    case 1:
                        gourmetCoffee.DisplayCatalog();

                        break;

                    case 2:
                        Console.Write("Product Code: ");

                        code = Console.ReadLine();

                        gourmetCoffee.DisplayProductInfo(code);

                        break;

                    case 3:
                        gourmetCoffee.DisplayOrder();

                        break;

                    case 4:
                        Console.Write("Product Code: ");

                        code = Console.ReadLine();

                        Console.Write("Quantity: ");

                        quantity = Convert.ToInt16(Console.ReadLine());

                        gourmetCoffee.AddModifyProduct(code, quantity);

                        break;

                    case 5:
                        Console.Write("Product Code: ");

                        code = Console.ReadLine();

                        gourmetCoffee.RemoveProduct(code);

                        break;

                    case 6:
                        gourmetCoffee.SaleOrder();

                        break;

                    case 7:
                        gourmetCoffee.DisplayOrdersSold();

                        break;

                    case 8:
                        Console.Write("Product Code: ");

                        code = Console.ReadLine();

                        gourmetCoffee.DisplayNumberOfOrders(code);

                        break;

                    case 9:
                        Console.Write("Product Code: ");

                        code = Console.ReadLine();

                        gourmetCoffee.DisplayTotalQuantityOfProducts(code);

                        break;
                }
            }
        }
    }
}
