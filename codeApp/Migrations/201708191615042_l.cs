namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CategoriesOfJobs", "CategorieId");
            AddForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "CategorieId", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "CategorieId" });
        }
    }
}
