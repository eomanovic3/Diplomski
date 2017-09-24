namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ImageEdits");
        }
        
        public override void Down()
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
    }
}
