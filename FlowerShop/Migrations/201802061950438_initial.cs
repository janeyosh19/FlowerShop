namespace FlowerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bouquets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BouquetName = c.String(),
                        Description = c.String(),
                        BouquetPrice = c.Decimal(precision: 18, scale: 2),
                        BouquetImage = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Telephone = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderBouquets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BouquetId = c.Int(nullable: false),
                        FlowerForBouquet = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bouquets", t => t.BouquetId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BouquetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBouquets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderBouquets", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.OrderBouquets", new[] { "BouquetId" });
            DropIndex("dbo.OrderBouquets", new[] { "CustomerId" });
            DropTable("dbo.OrderBouquets");
            DropTable("dbo.Flowers");
            DropTable("dbo.Customers");
            DropTable("dbo.Bouquets");
        }
    }
}
