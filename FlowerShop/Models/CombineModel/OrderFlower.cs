using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.Models.CombineModel
{
    public class OrderFlower
    {       
        public int Id  { get; set; }
        public Customer Customer { get; set; }
        public virtual int CustomerId { get; set; }
        public Flower Flower { get; set; }
        public virtual int FlowerId { get; set; }
        
      
    }
}