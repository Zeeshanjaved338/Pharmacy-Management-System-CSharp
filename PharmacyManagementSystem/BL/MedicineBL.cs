namespace PharmacyManagementSystem.BL
{
    public class Medicine
    {
        private string name;
        private int price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Medicine(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}