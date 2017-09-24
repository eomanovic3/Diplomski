namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followings8 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Followings", "Id", unique: true, name: "IdFollow");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Followings", "IdFollow");
        }
    }
}
