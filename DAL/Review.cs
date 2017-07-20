using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public int Rate { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
