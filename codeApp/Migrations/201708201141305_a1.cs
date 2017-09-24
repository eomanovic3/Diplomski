namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.CategorieOfferId)
                .ForeignKey("dbo.JobOffers", t => t.CategorieOfferId)
                .Index(t => t.CategorieOfferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoriesOfJobsOffers", "CategorieOfferId", "dbo.JobOffers");
            DropIndex("dbo.CategoriesOfJobsOffers", new[] { "CategorieOfferId" });
            DropTable("dbo.CategoriesOfJobsOffers");
        }
    }
}
