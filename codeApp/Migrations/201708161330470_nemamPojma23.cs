namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemamPojma23 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "CategorieId", newName: "Kategorije_CategorieId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CategorieId", newName: "IX_Kategorije_CategorieId");
            AddColumn("dbo.CategoriesOfJobs", "Id", c => c.String(maxLength: 128));
            DropColumn("dbo.CategoriesOfJobs", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoriesOfJobs", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.CategoriesOfJobs", "Id");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Kategorije_CategorieId", newName: "IX_CategorieId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Kategorije_CategorieId", newName: "CategorieId");
        }
    }
}
