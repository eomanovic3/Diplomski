namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CategoriesOfJobs", "Id", c => c.String(maxLength: 128));
        }
    }
}
