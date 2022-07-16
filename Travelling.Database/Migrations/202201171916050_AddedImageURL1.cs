namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageURL1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "ImageURL");
        }
    }
}
