namespace FlowerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class toalpricesinclassflower : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flowers", "TotalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flowers", "TotalPrice");
        }
    }
}
