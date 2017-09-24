namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deeOo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        IdJob = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdJob)
                .Index(t => t.IdJob, unique: true, name: "IdJobApplications");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JobApplications", "IdJobApplications");
            DropTable("dbo.JobApplications");
        }
    }
}
