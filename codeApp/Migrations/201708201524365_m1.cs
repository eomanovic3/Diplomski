namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageEdits",
                c => new
                    {
                        editImageId = c.String(nullable: false, maxLength: 128),
                        ImageFileId = c.Int(nullable: false),
                        ImageFileName = c.String(),
                        ImageFileContent = c.Binary(),
                    })
                .PrimaryKey(t => t.editImageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageEdits");
        }
    }
}
