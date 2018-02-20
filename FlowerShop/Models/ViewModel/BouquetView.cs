using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models
{
    public class BouquetView
    {       
        public string BouquetName { get; set; }
        public string Description{ get; set; }
        public decimal? BouquetPrice { get; set; }
        public string FlowerForBouquet { get; set; }



        public string CustomerName { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DeliveryDate { get; set; }



    }
}