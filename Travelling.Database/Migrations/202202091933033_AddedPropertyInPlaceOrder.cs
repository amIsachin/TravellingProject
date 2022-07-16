namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyInPlaceOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaceOrders", "Places_ID", "dbo.Places");
            DropIndex("dbo.PlaceOrders", new[] { "Places_ID" });
            AddColumn("dbo.PlaceOrders", "FirstName", c => c.String());
            AddColumn("dbo.PlaceOrders", "LastName", c => c.String());
            AddColumn("dbo.PlaceOrders", "UserName", c => c.String());
            AddColumn("dbo.PlaceOrders", "Email", c => c.String());
            AddColumn("dbo.PlaceOrders", "DestinationPlaceID", c => c.Int(nullable: false));
            AddColumn("dbo.PlaceOrders", "DestinationName", c => c.String());
            AddColumn("dbo.PlaceOrders", "DestinationDescription", c => c.String());
            AddColumn("dbo.PlaceOrders", "DestinationPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.PlaceOrders", "DestinationImageURL", c => c.String());
            AddColumn("dbo.PlaceOrders", "City_ID", c => c.Int());
            CreateIndex("dbo.PlaceOrders", "City_ID");
            AddForeignKey("dbo.PlaceOrders", "City_ID", "dbo.Cities", "ID");
            DropColumn("dbo.PlaceOrders", "CustomerName");
            DropColumn("dbo.PlaceOrders", "CustomerEmail");
            DropColumn("dbo.PlaceOrders", "CustomerPhoneNumber");
            DropColumn("dbo.PlaceOrders", "Name");
            DropColumn("dbo.PlaceOrders", "Description");
            DropColumn("dbo.PlaceOrders", "Price");
            DropColumn("dbo.PlaceOrders", "Places_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaceOrders", "Places_ID", c => c.Int());
            AddColumn("dbo.PlaceOrders", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.PlaceOrders", "Description", c => c.String());
            AddColumn("dbo.PlaceOrders", "Name", c => c.String());
            AddColumn("dbo.PlaceOrders", "CustomerPhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.PlaceOrders", "CustomerEmail", c => c.String());
            AddColumn("dbo.PlaceOrders", "CustomerName", c => c.String());
            DropForeignKey("dbo.PlaceOrders", "City_ID", "dbo.Cities");
            DropIndex("dbo.PlaceOrders", new[] { "City_ID" });
            DropColumn("dbo.PlaceOrders", "City_ID");
            DropColumn("dbo.PlaceOrders", "DestinationImageURL");
            DropColumn("dbo.PlaceOrders", "DestinationPrice");
            DropColumn("dbo.PlaceOrders", "DestinationDescription");
            DropColumn("dbo.PlaceOrders", "DestinationName");
            DropColumn("dbo.PlaceOrders", "DestinationPlaceID");
            DropColumn("dbo.PlaceOrders", "Email");
            DropColumn("dbo.PlaceOrders", "UserName");
            DropColumn("dbo.PlaceOrders", "LastName");
            DropColumn("dbo.PlaceOrders", "FirstName");
            CreateIndex("dbo.PlaceOrders", "Places_ID");
            AddForeignKey("dbo.PlaceOrders", "Places_ID", "dbo.Places", "ID");
        }
    }
}
