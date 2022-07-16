namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Cities", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Countries", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Places", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
        }
    }
}
