using System.Collections.Generic;

namespace PharmacyManagementSystem.BL
{
    public class OrderBL
    {
        private int receiptNo;
        private string username;
        private string customerName;
        private string date;
        private int totalItems;

        public int ReceiptNo
        {
            get { return receiptNo; }
            set { receiptNo = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; }
        }


        public List<CartItem> Cart { get; set; }

        public OrderBL()
        {
            Cart = new List<CartItem>();
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