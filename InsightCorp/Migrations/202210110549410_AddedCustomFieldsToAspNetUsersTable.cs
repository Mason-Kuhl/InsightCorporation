namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomFieldsToAspNetUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MiddleInitial", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PreferredName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateHired", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "ManagerName", c => c.String());
            AddColumn("dbo.AspNetUsers", "ManagerId", c => c.String());
            AddColumn("dbo.AspNetUsers", "DepartmentName", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "DepartmentName");
            DropColumn("dbo.AspNetUsers", "ManagerId");
            DropColumn("dbo.AspNetUsers", "ManagerName");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "DateHired");
            DropColumn("dbo.AspNetUsers", "PreferredName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "MiddleInitial");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
