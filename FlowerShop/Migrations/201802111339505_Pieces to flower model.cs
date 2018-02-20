namespace FlowerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Piecestoflowermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flowers", "Pieces", c => c.Int(nullable: false));
            DropColumn("dbo.OrderFlowers", "Pieces");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderFlowers", "Pieces", c => c.Int(nullable: false));
            DropColumn("dbo.Flowers", "Pieces");
        }
    }
}
