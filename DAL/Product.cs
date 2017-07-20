using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            Reviews = new HashSet<Review>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? CategoryId { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual Category Category { get; set; }
    }
}
