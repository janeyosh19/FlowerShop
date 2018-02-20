using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models.CombineModel
{
    public class OrderBouquet
    {   
        public int Id { get; set; }
        public  virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public  virtual Bouquet Bouquet { get; set; }
        public int BouquetId { get; set; }
        public string FlowerForBouquet { get; set; }


    }
}