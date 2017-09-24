namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nemamPojma2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Kategorija_CategorieId" });
            DropColumn("dbo.AspNetUsers", "CategorieId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Kategorija_CategorieId", newName: "CategorieId");
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "CategorieId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "CategorieId" });
            AlterColumn("dbo.AspNetUsers", "CategorieId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "CategorieId", newName: "Kategorija_CategorieId");
            AddColumn("dbo.AspNetUsers", "CategorieId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Kategorija_CategorieId");
        }
    }
}
