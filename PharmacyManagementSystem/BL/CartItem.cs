namespace PharmacyManagementSystem.BL
{
    public class CartItem
    {
        private int medId;
        private int quantity;

        public int MedId
        {
            get { return medId; }
            set { medId = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public CartItem(int medId, int quantity)
        {
            this.medId = medId;
            this.quantity = quantity;
        }
    }
}