using System;
using PharmacyManagementSystem.BL;
using PharmacyManagementSystem.DL;
using System.Collections.Generic;

namespace PharmacyManagementSystem.UI
{
    public static class AdminUI
    {
        private static List<Medicine> MedList = new List<Medicine>
        {
            new Medicine("Paracetamol", 20), new Medicine("Aspirin",15),
            new Medicine("Vitamin C",25), new Medicine("Antibiotic",50),
            new Medicine("Cough Syrup",30), new Medicine("Pain Relief",40),
            new Medicine("Multivitamin",35), new Medicine("Antacid",15),
            new Medicine("Insulin",100), new Medicine("ORS",10)
        };

        public static void Menu()
        {
            int ch;
            do
            {
                Console.WriteLine("====================================");
                Console.WriteLine($"    {UserUI.CurrentRole} MENU      ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Order\n2. View Orders\n3. Delete Order\n4. Search\n5. View Customers\n6. Logout");
                Console.Write("Choice: ");
                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1: 
                        CustomerUI.PlaceOrder(MedList); 
                        break;
                    case 2: CustomerUI.PlaceOrder(MedList);
                        CustomerUI.DisplayOrders(); 
                        break;
                    case 3:
                        CustomerUI.DeleteOrder();
                        break;
                    case 4: 
                        CustomerUI.SearchOrder(); 
                        break;
                    case 5: 
                        CustomerUI.ShowCustomers(); 
                        break;
                }
            } while (ch != 6);
        }
    }
}