namespace PharmacyManagementSystem.BL
{
    public class CustomerBL
    {
        private string username;
        private string password;
        private string fullName;
        private string contactNo;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public CustomerBL(string username, string password, string fullName, string contactNo)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.contactNo = contactNo;
        }
    }
}