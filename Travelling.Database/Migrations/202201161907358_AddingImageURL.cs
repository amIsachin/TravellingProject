namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImageURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "ImageURL");
        }
    }
}
