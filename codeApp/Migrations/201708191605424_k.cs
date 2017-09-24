namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "CategorieId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CategoriesOfJobs", "CategorieId");
            AddForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers", "Id");
        }
    }
}
