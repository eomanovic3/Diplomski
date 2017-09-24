namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriesOfJobs",
                c => new
                    {
                        CategorieId = c.String(nullable: false, maxLength: 128),
                        Id = c.String(),
                        Informatics = c.Boolean(nullable: false),
                        Education = c.Boolean(nullable: false),
                        Health_Care = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoriesOfJobs");
        }
    }
}
