namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoriesOfJobsOffers", "CategorieOfferId", "dbo.JobOffers");
            DropIndex("dbo.CategoriesOfJobsOffers", new[] { "CategorieOfferId" });
            AddColumn("dbo.JobOffers", "Informatics", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Education", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Health_Care", c => c.Boolean(nullable: false));
            DropTable("dbo.CategoriesOfJobsOffers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoriesOfJobsOffers",
                c => new
                    {
                        CategorieOfferId = c.Int(nullable: false),
                        Informatics = c.Boolean(nullable: false),
                        Education = c.Boolean(nullable: false),
                        Health_Care = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieOfferId);
            
            DropColumn("dbo.JobOffers", "Health_Care");
            DropColumn("dbo.JobOffers", "Education");
            DropColumn("dbo.JobOffers", "Informatics");
            CreateIndex("dbo.CategoriesOfJobsOffers", "CategorieOfferId");
            AddForeignKey("dbo.CategoriesOfJobsOffers", "CategorieOfferId", "dbo.JobOffers", "ID");
        }
    }
}
