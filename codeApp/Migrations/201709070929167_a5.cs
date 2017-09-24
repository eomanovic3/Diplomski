namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsFeeds",
                c => new
                    {
                        newsfeedId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        url = c.String(),
                        urltoimage = c.String(),
                    })
                .PrimaryKey(t => t.newsfeedId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsFeeds");
        }
    }
}
