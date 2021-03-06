namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableInPlaceOrderPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlaceOrders", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlaceOrders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
