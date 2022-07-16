namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "ImageURL");
        }
    }
}
