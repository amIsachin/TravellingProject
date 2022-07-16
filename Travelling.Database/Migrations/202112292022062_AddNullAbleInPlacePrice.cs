namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullAbleInPlacePrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
