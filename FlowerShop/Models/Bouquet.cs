using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FlowerShop.Models
{
    public class Bouquet
    {
        public int Id { get; set; }
        public string BouquetName { get; set; }
        public string Description{ get; set; }
        public decimal? BouquetPrice { get; set; }
        public byte[] BouquetImage { get; set; }

        
    }

   
}