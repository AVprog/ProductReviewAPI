using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Customer
    {
        public Customer()
        {
            Reviews = new HashSet<Review>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
