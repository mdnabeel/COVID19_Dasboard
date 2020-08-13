namespace Covid19_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CovidStatus", "EmployeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CovidStatus", "EmployeId");
        }
    }
}
