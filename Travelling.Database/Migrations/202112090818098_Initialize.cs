namespace Travelling.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .Index(t => t.Country_ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Description = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Places", new[] { "City_ID" });
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            DropTable("dbo.Places");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
