using System;
using System.Collections.Generic;
using System.IO;
using PharmacyManagementSystem.BL;

namespace PharmacyManagementSystem.DL
{
    public static class OrderDL
    {
        public static List<OrderBL> Orders = new List<OrderBL>();

        public static void LoadOrders()
        {
            if (!File.Exists("orders.txt")) return;

            foreach (var line in File.ReadAllLines("orders.txt"))
            {
                var parts = line.Split('|');
                if (parts.Length >= 5)
                {
                    OrderBL o = new OrderBL();
                    o.ReceiptNo = int.Parse(parts[0]);
                    o.Username = parts[1];
                    o.CustomerName = parts[2];
                    o.Date = parts[3];
                    o.TotalItems = int.Parse(parts[4]);

                    for (int i = 0; i < o.TotalItems; i++)
                    {
                        var cartParts = parts[5 + i].Split(',');
                        o.Cart.Add((int.Parse(cartParts[0]), int.Parse(cartParts[1])));
                    }
                    Orders.Add(o);
                }
            }
        }

        public static void SaveOrder(OrderBL o)
        {
            Orders.Add(o);
            string line = $"{o.ReceiptNo}|{o.Username}|{o.CustomerName}|{o.Date}|{o.TotalItems}";
            foreach (var item in o.Cart)
                line += $"|{item.MedId},{item.Quantity}";
            File.AppendAllText("orders.txt", line + "\n");
        }

        public static void DeleteOrder(int receiptNo)
        {
            var order = Orders.Find(o => o.ReceiptNo == receiptNo);
            if (order != null)
            {
                Orders.Remove(order);
                using (StreamWriter sw = new StreamWriter("orders.txt"))
                {
                    foreach (var o in Orders)
                    {
                        string line = $"{o.ReceiptNo}|{o.Username}|{o.CustomerName}|{o.Date}|{o.TotalItems}";
                        foreach (var item in o.Cart)
                            line += $"|{item.MedId},{item.Quantity}";
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("Deleted Successfully.");
            }
            else Console.WriteLine("Not found.");
        }
    }
}