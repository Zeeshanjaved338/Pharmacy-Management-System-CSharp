using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    public class OrderBL
    {
        public int ReceiptNo { get; set; }
        public string Username { get; set; }
        public string CustomerName { get; set; }
        public string Date { get; set; }
        public int TotalItems { get; set; }
        public List<(int MedId, int Quantity)> Cart { get; set; }

        public OrderBL()
        {
            Cart = new List<(int, int)>();
        }

        public int GetTotal(List<Medicine> medList)
        {
            int total = 0;
            foreach (var item in Cart)
            {
                total += medList[item.MedId - 1].Price * item.Quantity;
            }
            return total;
        }
    }
}
