namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Status", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Status", c => c.String(nullable: false));
        }
    }
}
