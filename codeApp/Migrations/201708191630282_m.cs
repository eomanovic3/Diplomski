namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.JobOffers", "ApplicationUser_Id");
            AddForeignKey("dbo.JobOffers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.JobOffers", "ApplicationUser_Id");
        }
    }
}
