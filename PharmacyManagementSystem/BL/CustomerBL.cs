using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    public class CustomerBL
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ContactNo { get; set; }

        public CustomerBL(string username, string password, string fullName, string contactNo)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            ContactNo = contactNo;
        }
    }
}