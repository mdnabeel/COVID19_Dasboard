namespace Covid19_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameEmployementNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "EmpNo", c => c.Int(nullable: false));
            DropColumn("dbo.Employes", "EmpID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employes", "EmpID", c => c.Int(nullable: false));
            DropColumn("dbo.Employes", "EmpNo");
        }
    }
}
