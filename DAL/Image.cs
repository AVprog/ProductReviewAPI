using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
