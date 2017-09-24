namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followings99 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Followings", "IdFollow");
            DropPrimaryKey("dbo.Followings");
            AlterColumn("dbo.Followings", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Followings", "Id");
            CreateIndex("dbo.Followings", "Id", unique: true, name: "IdFollow");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Followings", "IdFollow");
            DropPrimaryKey("dbo.Followings");
            AlterColumn("dbo.Followings", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Followings", "Id");
            CreateIndex("dbo.Followings", "Id", unique: true, name: "IdFollow");
        }
    }
}
