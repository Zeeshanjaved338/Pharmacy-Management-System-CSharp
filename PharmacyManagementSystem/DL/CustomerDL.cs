using System;
using System.Collections.Generic;
using System.IO;
using PharmacyManagementSystem.BL;

namespace PharmacyManagementSystem.DL
{
    public static class CustomerDL
    {
        public static List<CustomerBL> Customers = new List<CustomerBL>();

        public static void LoadCustomers()
        {
            if (!File.Exists("customers.txt")) return;

            foreach (var line in File.ReadAllLines("customers.txt"))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                    Customers.Add(new CustomerBL(parts[0], "", parts[1], parts[2]));
            }
        }

        public static void SaveCustomer(CustomerBL c)
        {
            Customers.Add(c);
            File.AppendAllText("customers.txt", $"{c.Username}|{c.FullName}|{c.ContactNo}\n");
        }
    }
}