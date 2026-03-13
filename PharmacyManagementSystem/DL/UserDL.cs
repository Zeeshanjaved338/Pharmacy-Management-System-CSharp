using System;
using System.Collections.Generic;
using System.IO;
using PharmacyManagementSystem.BL;

namespace PharmacyManagementSystem.DL
{
    public static class UserDL
    {
        public static List<MUser> Users = new List<MUser>();

        public static void LoadUsers()
        {
            if (!File.Exists("users.txt"))
            {
                File.WriteAllText("users.txt", "admin@gmail.com admin123 Admin\npharma@gmail.com pharma123 Pharmacist\n");
            }

            foreach (var line in File.ReadAllLines("users.txt"))
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                    Users.Add(new MUser(parts[0], parts[1], parts[2]));
            }
        }

        public static void AddUser(MUser u)
        {
            Users.Add(u);
            File.AppendAllText("users.txt", $"{u.Username} {u.Password} {u.Role}\n");
        }

        public static MUser ValidateUser(string username, string password, string role)
        {
            foreach (var u in Users)
            {
                if (u.Username == username && u.Password == password && u.Role == role)
                    return u;
            }
            return null;
        }
    }
}