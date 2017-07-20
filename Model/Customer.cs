using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
