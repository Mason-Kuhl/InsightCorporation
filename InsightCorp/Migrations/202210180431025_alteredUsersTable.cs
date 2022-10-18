namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredUsersTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ManagerId", c => c.Int(nullable: true));
            DropColumn("dbo.AspNetUsers", "ManagerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ManagerName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ManagerId", c => c.String());
        }
    }
}
