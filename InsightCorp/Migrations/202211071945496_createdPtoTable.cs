namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdPtoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PtoRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ManagerId = c.String(),
                        RequestedDayOff = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PtoRequests");
        }
    }
}
