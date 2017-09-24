namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Userfk = c.String(maxLength: 128),
                        Description = c.String(nullable: false),
                        MailForApplication = c.String(nullable: false),
                        NumberOfPositions = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        PublishingDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Userfk)
                .Index(t => t.Userfk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "Userfk", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "Userfk" });
            DropTable("dbo.JobOffers");
        }
    }
}
