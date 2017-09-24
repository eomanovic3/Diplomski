namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobOffers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobOffers", "Name", c => c.String(nullable: false));
        }
    }
}
