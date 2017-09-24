namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImageFileId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ImageFileName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageFileContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageFileContent");
            DropColumn("dbo.AspNetUsers", "ImageFileName");
            DropColumn("dbo.AspNetUsers", "ImageFileId");
        }
    }
}
