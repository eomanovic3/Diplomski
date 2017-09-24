namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class o : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOffers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.JobOffers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        MailForApplication = c.String(nullable: false),
                        NumberOfPositions = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        PublishingDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.JobOffers", "ApplicationUser_Id");
            AddForeignKey("dbo.JobOffers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
