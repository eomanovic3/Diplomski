namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NewsFeeds", newName: "Articles");
            AddColumn("dbo.Articles", "author", c => c.String());
            AddColumn("dbo.Articles", "publishedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "publishedAt");
            DropColumn("dbo.Articles", "author");
            RenameTable(name: "dbo.Articles", newName: "NewsFeeds");
        }
    }
}
