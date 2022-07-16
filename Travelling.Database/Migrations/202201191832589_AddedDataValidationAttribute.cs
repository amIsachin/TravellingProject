namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataValidationAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Countries", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Description", c => c.String());
            AlterColumn("dbo.Places", "Name", c => c.String());
            AlterColumn("dbo.Countries", "Description", c => c.String());
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Countries", "ImageURL", c => c.String());
            AlterColumn("dbo.Cities", "Description", c => c.String());
            AlterColumn("dbo.Cities", "Name", c => c.String());
        }
    }
}
