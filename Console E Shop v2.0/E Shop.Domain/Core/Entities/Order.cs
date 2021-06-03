using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace E_Shop.Domain.Core.Entities
{
    public class Order : BaseEntity
    {
        private List<OrderList> _orders = new List<OrderList>();

        public Order()
        {

        }

        public void AddOrder(Bicycle product, int quantity, int index)
        {
            OrderList line = new OrderList();
            line.Index = index;
            line.ProductName = product.Name;
            line.Quantity = quantity;
            line.Price = product.Price;
            _orders.Add(line);
        }

     
        public int GetCount()
        {
            return _orders.Count;
        }
        public int OrderTotal()
        {
            int total = _orders.Sum(x => x.OrdersTotal());
            return total;
        }

        public override void Print()
        {
            Console.WriteLine("\t=========================================================");
            foreach (var orders in _orders)
            {
                Console.WriteLine($"\tId: {orders.Index} | Product Model: {orders.ProductName} | Quantity:  {orders.Quantity} | Price: {orders.Price} MKD |" +
                    $" Total Price: {orders.OrdersTotal()} MKD");
            }
        }


        public string PrintForReceipt()
        {
            string allProducts = $"\n\tID:|  Product Name:  ";

            foreach (var orders in _orders)
            {
                allProducts += $"\n\t{orders.Index} | {orders.ProductName} ";
            }


             allProducts += $"\n\tQuantity:|Price:|Total Price:";

            foreach (var orders in _orders)
            {
                allProducts += $"\n\t{orders.Quantity}  |  {orders.Price} MKD | " +
                    $" {orders.OrdersTotal()} MKD ";
            }
            allProducts += $"\n\t=============================\n\t\t Total: {OrderTotal()} MKD";

            return allProducts;
        }
        public void RemoveItemFromOrder(int id)
        {          
            var item = _orders.FirstOrDefault(x => x.Index == id);
            if (item == null)
            {
                Console.WriteLine("\tNo such item to remove or empty Shoping cart ...");
                Thread.Sleep(3000);
                return;
            }
            _orders.Remove(item);
            Console.WriteLine("\tItem Successfully removed");
            Thread.Sleep(3000);
        }
    
        private class OrderList
        {
            public string ProductName { get; set; }
            public int Index { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
            public int OrdersTotal()
            {
                return Price * Quantity;
            }
        }



    }
}
