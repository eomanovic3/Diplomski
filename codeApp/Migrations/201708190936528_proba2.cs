namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.AspNetUsers", new[] { "CategorieId" });
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.String());
            CreateIndex("dbo.CategoriesOfJobs", "Id");
            AddForeignKey("dbo.CategoriesOfJobs", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "Id" });
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.String(maxLength: 128));
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String());
            CreateIndex("dbo.AspNetUsers", "CategorieId");
            AddForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
    }
}
