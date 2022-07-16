namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlaceOrderEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaceOrders",
                c => new
                    {
                        BoodingID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerEmail = c.String(),
                        CustomerPhoneNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Places_ID = c.Int(),
                    })
                .PrimaryKey(t => t.BoodingID)
                .ForeignKey("dbo.Places", t => t.Places_ID)
                .Index(t => t.Places_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceOrders", "Places_ID", "dbo.Places");
            DropIndex("dbo.PlaceOrders", new[] { "Places_ID" });
            DropTable("dbo.PlaceOrders");
        }
    }
}
