namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promjeniduzinu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoriesOfJobs", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoriesOfJobs", "UserId", c => c.String());
        }
    }
}
