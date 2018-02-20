using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.Models.CombineModel;

namespace FlowerShop.Models.ViewModel
{
    public class CustomerView
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Pieces { get; set; }
        public decimal? TotalPrice { get; set; }

         public string BouquetName { get; set; }
        public string Description{ get; set; }
        public decimal? BouquetPrice { get; set; }
        public string FlowerForBouquet { get; set; }

        public string CustomerName { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DeliveryDate { get; set; }

        public List<OrderBouquet> OrderBouquet { get; set; }
        public List<OrderFlower> OrderFlower { get; set; }
    }
}