namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.AspNetUsers", new[] { "CategorieId" });
            DropColumn("dbo.AspNetUsers", "CategorieId");
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
            
            AddColumn("dbo.AspNetUsers", "CategorieId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "CategorieId");
            AddForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
    }
}
