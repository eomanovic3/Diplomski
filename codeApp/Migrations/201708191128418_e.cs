namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEdits", "CategoriesOfJobs_CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.UserEdits", new[] { "CategoriesOfJobs_CategorieId" });
            DropTable("dbo.UserEdits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserEdits",
                c => new
                    {
                        EditId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        UserType = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        FileName = c.String(),
                        FileContent = c.Binary(),
                        CategoriesOfJobs_CategorieId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EditId);
            
            CreateIndex("dbo.UserEdits", "CategoriesOfJobs_CategorieId");
            AddForeignKey("dbo.UserEdits", "CategoriesOfJobs_CategorieId", "dbo.CategoriesOfJobs", "CategorieId");
        }
    }
}
