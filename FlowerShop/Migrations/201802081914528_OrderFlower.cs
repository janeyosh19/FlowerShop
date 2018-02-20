namespace FlowerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderFlower : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderFlowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FlowerId = c.Int(nullable: false),
                        Pieces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Flowers", t => t.FlowerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FlowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderFlowers", "FlowerId", "dbo.Flowers");
            DropForeignKey("dbo.OrderFlowers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderFlowers", new[] { "FlowerId" });
            DropIndex("dbo.OrderFlowers", new[] { "CustomerId" });
            DropTable("dbo.OrderFlowers");
        }
    }
}
