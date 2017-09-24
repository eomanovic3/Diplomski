namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriesOfJobs",
                c => new
                    {
                        CategorieId = c.String(nullable: false, maxLength: 128),
                        Informatics = c.Boolean(nullable: false),
                        Education = c.Boolean(nullable: false),
                        Health_Care = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieId)
                .ForeignKey("dbo.AspNetUsers", t => t.CategorieId)
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "CategorieId" });
            DropTable("dbo.CategoriesOfJobs");
        }
    }
}
