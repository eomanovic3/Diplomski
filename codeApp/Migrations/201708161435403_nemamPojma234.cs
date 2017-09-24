namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemamPojma234 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Kategorije_CategorieId", newName: "CategorieId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Kategorije_CategorieId", newName: "IX_CategorieId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CategorieId", newName: "IX_Kategorije_CategorieId");
            RenameColumn(table: "dbo.AspNetUsers", name: "CategorieId", newName: "Kategorije_CategorieId");
        }
    }
}
