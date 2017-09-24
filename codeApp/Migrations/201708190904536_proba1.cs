namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CategorieId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "CategorieId");
            AddForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.AspNetUsers", new[] { "CategorieId" });
            DropColumn("dbo.AspNetUsers", "CategorieId");
        }
    }
}
