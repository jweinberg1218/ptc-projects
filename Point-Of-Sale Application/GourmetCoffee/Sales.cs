using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class Sales
    {
        private List<Order> orders;

        public Sales()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order>.Enumerator GetEnumerator()
        {
            return orders.GetEnumerator();
        }

        public int GetNumberOfOrders()
        {
            return orders.Count;
        }
    }
}
