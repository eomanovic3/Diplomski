namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followings7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FollowerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Followings", "FollowerId");
            AddForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers", "Id");
        }
    }
}
