namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CompanyName", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "CompanyDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CompanyDescription");
            DropColumn("dbo.AspNetUsers", "CompanyAddress");
            DropColumn("dbo.AspNetUsers", "CompanyName");
        }
    }
}
