namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdPayrollTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payrolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Salary = c.Double(nullable: false),
                        RequestedRaise = c.Double(nullable: true),
                        LastRaise = c.Double(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payrolls");
        }
    }
}
