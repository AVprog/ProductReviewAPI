using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }
    }
}
