namespace InsightCorp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeededAspNetRolesTable : DbMigration
    {
        public override void Up()
        {

            Sql(@"

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Employee')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Manager')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Executive')

            ");

        }
        
        public override void Down()
        {
        }
    }
}
