namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ManagerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ManagerId", c => c.Int(nullable: false));
        }
    }
}
