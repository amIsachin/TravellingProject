namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlaceOrders", "PlaceID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlaceOrders", "PlaceID", c => c.Int(nullable: false));
        }
    }
}
