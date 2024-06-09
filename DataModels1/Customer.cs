using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels1
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFullName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerBirthday { get; set; }
        public int CustomerStatus { get; set; } // 1 Active, 2 Deleted
        public string Password { get; set; }
    }
}
