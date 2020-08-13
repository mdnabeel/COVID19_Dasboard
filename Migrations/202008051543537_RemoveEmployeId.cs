namespace Covid19_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmployeId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CovidStatus", "EmployeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CovidStatus", "EmployeId", c => c.Byte(nullable: false));
        }
    }
}
