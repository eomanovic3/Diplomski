namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rpp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobOffers", name: "ApplicationUser_Id", newName: "Userfk");
            RenameIndex(table: "dbo.JobOffers", name: "IX_ApplicationUser_Id", newName: "IX_Userfk");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.JobOffers", name: "IX_Userfk", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.JobOffers", name: "Userfk", newName: "ApplicationUser_Id");
        }
    }
}
