namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataValidationAttribute1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Places", "City_ID", "dbo.Cities");
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            DropIndex("dbo.Places", new[] { "City_ID" });
            AlterColumn("dbo.Cities", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Cities", "Country_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Places", "ImageURL", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "City_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "Country_ID");
            CreateIndex("dbo.Places", "City_ID");
            AddForeignKey("dbo.Cities", "Country_ID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Places", "City_ID", "dbo.Cities", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Places", new[] { "City_ID" });
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            AlterColumn("dbo.Places", "City_ID", c => c.Int());
            AlterColumn("dbo.Places", "ImageURL", c => c.String());
            AlterColumn("dbo.Cities", "Country_ID", c => c.Int());
            AlterColumn("dbo.Cities", "ImageURL", c => c.String());
            CreateIndex("dbo.Places", "City_ID");
            CreateIndex("dbo.Cities", "Country_ID");
            AddForeignKey("dbo.Places", "City_ID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Cities", "Country_ID", "dbo.Countries", "ID");
        }
    }
}
