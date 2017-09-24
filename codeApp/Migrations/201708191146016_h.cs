namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "CategorieId" });
            DropTable("dbo.CategoriesOfJobs");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CategorieId);
            
            CreateIndex("dbo.CategoriesOfJobs", "CategorieId");
            AddForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers", "Id");
        }
    }
}
