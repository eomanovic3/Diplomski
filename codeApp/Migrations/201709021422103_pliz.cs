namespace codeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pliz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "Hardware", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Software", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "IT", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Architecture", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Banking", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Construction", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "MechanicalEngineering", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "RealEstate", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Health", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Marketing", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Law", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Turism", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Government", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Accounting", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Engineering", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Insurance", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Fun", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Administrative", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Others", c => c.Boolean(nullable: false));
            DropColumn("dbo.JobOffers", "Informatics");
            DropColumn("dbo.JobOffers", "Health_Care");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOffers", "Health_Care", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobOffers", "Informatics", c => c.Boolean(nullable: false));
            DropColumn("dbo.JobOffers", "Others");
            DropColumn("dbo.JobOffers", "Administrative");
            DropColumn("dbo.JobOffers", "Fun");
            DropColumn("dbo.JobOffers", "Insurance");
            DropColumn("dbo.JobOffers", "Engineering");
            DropColumn("dbo.JobOffers", "Accounting");
            DropColumn("dbo.JobOffers", "Government");
            DropColumn("dbo.JobOffers", "Turism");
            DropColumn("dbo.JobOffers", "Law");
            DropColumn("dbo.JobOffers", "Marketing");
            DropColumn("dbo.JobOffers", "Health");
            DropColumn("dbo.JobOffers", "RealEstate");
            DropColumn("dbo.JobOffers", "MechanicalEngineering");
            DropColumn("dbo.JobOffers", "Construction");
            DropColumn("dbo.JobOffers", "Banking");
            DropColumn("dbo.JobOffers", "Architecture");
            DropColumn("dbo.JobOffers", "IT");
            DropColumn("dbo.JobOffers", "Software");
            DropColumn("dbo.JobOffers", "Hardware");
        }
    }
}
