using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    public class MUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public MUser(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}

