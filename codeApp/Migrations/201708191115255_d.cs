namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.EditId)
                .ForeignKey("dbo.CategoriesOfJobs", t => t.CategoriesOfJobs_CategorieId)
                .Index(t => t.CategoriesOfJobs_CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEdits", "CategoriesOfJobs_CategorieId", "dbo.CategoriesOfJobs");
            DropIndex("dbo.UserEdits", new[] { "CategoriesOfJobs_CategorieId" });
            DropTable("dbo.UserEdits");
        }
    }
}
