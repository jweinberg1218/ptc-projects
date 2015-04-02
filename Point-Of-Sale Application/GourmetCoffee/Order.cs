using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class Order
    {
        private List<OrderItem> items;

        public Order()
        {
            items = new List<OrderItem>();
        }

        public void AddItem(OrderItem orderItem)
        {
            items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            items.Remove(orderItem);
        }

        public List<OrderItem>.Enumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public OrderItem GetItem(Product product)
        {
            foreach (OrderItem orderItem in items)
            {
                if (orderItem.Product.Equals(product))
                {
                    return orderItem;
                }
            }

            return null;
        }

        public int GetNumberOfItems()
        {
            return items.Count;
        }

        public double GetTotalCost()
        {
            double totalCost = 0;

            foreach (OrderItem orderItem in items)
            {
                totalCost += orderItem.Product.Price;
            }

            return totalCost;
        }
    }
}
