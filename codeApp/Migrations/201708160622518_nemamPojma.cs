namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemamPojma : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        MailForApplication = c.String(nullable: false),
                        NumberOfPositions = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        PublishingDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "CategorieId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Kategorija_CategorieId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Kategorija_CategorieId");
            AddForeignKey("dbo.AspNetUsers", "Kategorija_CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Kategorija_CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.AspNetUsers", new[] { "Kategorija_CategorieId" });
            DropColumn("dbo.AspNetUsers", "Kategorija_CategorieId");
            DropColumn("dbo.AspNetUsers", "CategorieId");
            DropTable("dbo.JobOffers");
        }
    }
}
