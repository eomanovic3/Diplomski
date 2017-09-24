namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followings2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropTable("dbo.Followings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        FollowerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Followings", "FollowerId");
            AddForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers", "Id");
        }
    }
}
