using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models.ViewModel
{
    public class AddFlowerToCart
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public byte[] Image { get; set; }
        public int Pieces { get; set; }
        public decimal? TotalPrice { get; set; }

        
    }
}