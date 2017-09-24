namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CategoriesOfJobs", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoriesOfJobs", "Id", c => c.String());
        }
    }
}
