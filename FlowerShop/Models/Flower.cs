using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FlowerShop.Models.CombineModel;

namespace FlowerShop.Models
{
    public class Flower
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public byte[] Image { get; set; }
        public int Pieces { get; set; }
        public decimal? TotalPrice { get; set; }

    }


    public class FlowerContext : DbContext
    {
        public DbSet<OrderFlower> OrderFlowers{ get; set; }
        public DbSet<OrderBouquet> OrderBouquets { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }


    
}