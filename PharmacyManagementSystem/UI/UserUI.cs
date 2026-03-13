using System;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;

namespace PharmacyManagementSystem.UI
{
    public static class UserUI
    {
        public static string CurrentRole;
        public static string CurrentUser;

        public static void MainMenu()
        {
            UserDL.LoadUsers();
            CustomerDL.LoadCustomers();
            OrderDL.LoadOrders();

            int opt;
            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("    PHARMACY MANAGEMENT SYSTEM      ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Admin\n2. Pharmacist\n3. Customer\n4. Exit");
                Console.Write("Select Role: ");
                if (!int.TryParse(Console.ReadLine(), out opt)) { 
                    Console.WriteLine("Invalid choice."); continue; 
                }
                if (opt == 4) break;

                CurrentRole = opt == 1 ? "Admin" : opt == 2 ? "Pharmacist" : "Customer";
                if (LoginProcess())
                {
                    if (opt == 1) 
                        AdminUI.Menu();
                    else if (opt == 2) 
                        PharmacistUI.Menu();
                    else 
                        CustomerUI.Menu();
                }
            }
        }

        public static bool LoginProcess()
        {
            if (CurrentRole == "Customer")
            {
                Console.WriteLine("1. Login\n2. Register");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 2) CustomerUI.Register();
            }

            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine($"      {CurrentRole} LOGIN          ");
                Console.WriteLine("====================================");
                Console.Write("Email/User: "); string username = Console.ReadLine();
                Console.Write("Password: "); string password = Console.ReadLine();

                MUser user = UserDL.ValidateUser(username, password, CurrentRole);
                if (user != null || CurrentRole == "Customer")
                {
                    CurrentUser = username;
                    return true;
                }
                Console.WriteLine("[!] Invalid credentials. Try again.");
            }
        }
    }
}