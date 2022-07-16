namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlaceIDInPlaceOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlaceOrders", "PlaceID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlaceOrders", "PlaceID");
        }
    }
}
