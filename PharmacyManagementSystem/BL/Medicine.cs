using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.BL
{
    public class Medicine
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Medicine(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
