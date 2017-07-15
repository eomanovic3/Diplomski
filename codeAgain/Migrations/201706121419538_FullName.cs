namespace codeAgain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsEmailVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Telephone", c => c.String());
            AddColumn("dbo.AspNetUsers", "Usernameee", c => c.String());
            AddColumn("dbo.AspNetUsers", "ActivationCode", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Employer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Employer");
            DropColumn("dbo.AspNetUsers", "ActivationCode");
            DropColumn("dbo.AspNetUsers", "Usernameee");
            DropColumn("dbo.AspNetUsers", "Telephone");
            DropColumn("dbo.AspNetUsers", "IsEmailVerified");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
