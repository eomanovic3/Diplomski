namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticlesMores",
                c => new
                    {
                        newsId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.newsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticlesMores");
        }
    }
}
