namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobOffers", name: "fkJob", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.JobOffers", name: "IX_fkJob", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobOffers", name: "IX_ApplicationUser_Id", newName: "IX_fkJob");
            RenameColumn(table: "dbo.JobOffers", name: "ApplicationUser_Id", newName: "fkJob");
        }
    }
}
