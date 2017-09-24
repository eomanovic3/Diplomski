namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.JobOffers");
        }
    }
}
