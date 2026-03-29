using System;
using System.Collections.Generic;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;

namespace PharmacyManagementSystem.UI
{
    public static class CustomerUI
    {
        private static List<Medicine> MedList = new List<Medicine>
        {
            new Medicine("Paracetamol", 20), new Medicine("Aspirin",15),
            new Medicine("Vitamin C",25), new Medicine("Antibiotic",50),
            new Medicine("Cough Syrup",30), new Medicine("Pain Relief",40),
            new Medicine("Multivitamin",35), new Medicine("Antacid",15),
            new Medicine("Insulin",100), new Medicine("ORS",10)
        };

        public static void Register()
        {
            Console.WriteLine("Welcome to Pharmacy Management System");
            Console.WriteLine("Please register to continue.");
            Console.WriteLine("================================");
            Console.WriteLine("       NEW REGISTRATION         ");
            Console.WriteLine("================================");
            Console.Write("Full Name: "); string fullName = Console.ReadLine();

            string username;
            while (true)
            {
                Console.Write("Enter Gmail: "); 
                username = Console.ReadLine();
                if (username.Contains("@")) 
                    break;
                Console.WriteLine("[!] Invalid format. Use @ symbol.");
            }

            Console.Write("Password: "); 
            string password = Console.ReadLine();
            Console.Write("Contact: "); 
            string contact = Console.ReadLine();

            CustomerBL c = new CustomerBL(username, password, fullName, contact);
            CustomerDL.SaveCustomer(c);
            UserDL.AddUser(new MUser(username, password, "Customer"));
            Console.WriteLine("Registered successfully.");
        }

        public static void PlaceOrder(List<Medicine> medList)
        {
            Console.WriteLine("**** ADD ORDER ****");
            OrderBL o = new OrderBL();

            Console.Write("Receipt #: "); o.ReceiptNo = int.Parse(Console.ReadLine());
            o.Username = UserUI.CurrentUser;
            var customer = CustomerDL.Customers.Find(c => c.Username == UserUI.CurrentUser);

            if (customer != null)
            {
                o.CustomerName = customer.FullName;
            }
            else
            {
                Console.Write("Enter Customer Name: ");
                o.CustomerName = Console.ReadLine();
            }

            Console.Write("Date (DD/MM/YYYY): "); o.Date = Console.ReadLine();
            Console.Write("Number of items: "); o.TotalItems = int.Parse(Console.ReadLine());

            for (int i = 0; i < o.TotalItems; i++)
            {
                Console.WriteLine($"Select Med ID (1-10) for item {i + 1}: "); int id = int.Parse(Console.ReadLine());
                Console.Write("Quantity: "); int qty = int.Parse(Console.ReadLine());
                o.Cart.Add(new CartItem(id, qty));
            }

            OrderDL.SaveOrder(o);
            Console.WriteLine("Order Saved!");
        }

        public static void DisplayOrders()
        {
            if (OrderDL.Orders.Count == 0) {
                Console.WriteLine("No orders."); 
                return; 
            }

            foreach (var o in OrderDL.Orders)
            {
                if (UserUI.CurrentRole == "Customer" && o.Username != UserUI.CurrentUser)
                    continue;
                Console.WriteLine("*********************************");
                Console.WriteLine($"Receipt: {o.ReceiptNo} | Name: {o.CustomerName}");
                foreach (var item in o.Cart)
                {
                    var med = MedList[item.MedId - 1];
                    Console.WriteLine($"  > {med.Name} x{item.Quantity} = {med.Price * item.Quantity}");
                }
                Console.WriteLine($"Total Bill: {o.GetTotal(MedList)}\n-------------------------");
            }
        }

        public static void DeleteOrder()
        {
            Console.Write("Enter Receipt to delete: "); 
            int r = int.Parse(Console.ReadLine());
            OrderDL.DeleteOrder(r);
        }

        public static void SearchOrder()
        {
            
            Console.Write("Enter Receipt: ");
            int r = int.Parse(Console.ReadLine());
            var o = OrderDL.Orders.Find(ord => ord.ReceiptNo == r);
            if (o != null)
            {
                if (UserUI.CurrentRole == "Customer" && o.Username != UserUI.CurrentUser)
                {
                    Console.WriteLine("[!] Access Denied. You can only search for your own orders."); return;
                }

                Console.WriteLine("******************************************");
                Console.WriteLine($"Receipt #: {o.ReceiptNo} | Customer: {o.CustomerName} | Date: {o.Date}");
                foreach (var item in o.Cart)
                {
                    var med = MedList[item.MedId - 1];
                    Console.WriteLine($" > {med.Name} x{item.Quantity} = {med.Price * item.Quantity}");
                }
                Console.WriteLine($"TOTAL BILL: {o.GetTotal(MedList)}");
                Console.WriteLine("----------------------------");
            }
            else Console.WriteLine("[!] Order not found.");
        }

        public static void ShowCustomers()
        {
            Console.WriteLine("===============================");
            Console.WriteLine("    REGISTERED CUSTOMERS       ");
            Console.WriteLine("===============================");
            int i = 1;
            foreach (var c in CustomerDL.Customers)
                Console.WriteLine($"{i++}. {c.FullName} ({c.ContactNo})");
        }

        public static void Menu()
        {
            int ch;
            do
            {
                Console.WriteLine("\n****  CUSTOMER MENU ****");
                Console.WriteLine("1. Buy Meds\n2. My Orders\n3. Search My Order\n4. Logout");
                Console.Write("Choice: "); 
                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1: PlaceOrder(MedList); break;
                    case 2: DisplayOrders(); break;
                    case 3: SearchOrder(); break;
                }
            } while (ch != 4);
        }
    }
}