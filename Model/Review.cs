using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public int Rate { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
    }
}
