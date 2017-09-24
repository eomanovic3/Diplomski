namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobOffers", name: "ApplicationUser_Id", newName: "fkJob");
            RenameIndex(table: "dbo.JobOffers", name: "IX_ApplicationUser_Id", newName: "IX_fkJob");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobOffers", name: "IX_fkJob", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.JobOffers", name: "fkJob", newName: "ApplicationUser_Id");
        }
    }
}
