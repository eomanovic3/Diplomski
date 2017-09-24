namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoriesOfJobs", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.CategoriesOfJobs", new[] { "Id" });
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String());
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "CategorieId");
            AddForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.AspNetUsers", new[] { "CategorieId" });
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.String());
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CategoriesOfJobs", "Id");
            AddForeignKey("dbo.CategoriesOfJobs", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
