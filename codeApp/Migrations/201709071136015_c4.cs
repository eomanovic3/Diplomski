namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "name", c => c.String());
            AddColumn("dbo.Articles", "country", c => c.String());
            DropColumn("dbo.Articles", "title");
            DropColumn("dbo.Articles", "author");
            DropColumn("dbo.Articles", "urltoimage");
            DropColumn("dbo.Articles", "publishedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "publishedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articles", "urltoimage", c => c.String());
            AddColumn("dbo.Articles", "author", c => c.String());
            AddColumn("dbo.Articles", "title", c => c.String());
            DropColumn("dbo.Articles", "country");
            DropColumn("dbo.Articles", "name");
        }
    }
}
