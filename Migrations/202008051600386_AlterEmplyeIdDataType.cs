namespace Covid19_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmplyeIdDataType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CovidStatus", "Employe_Id", "dbo.Employes");
            DropIndex("dbo.CovidStatus", new[] { "Employe_Id" });
            DropColumn("dbo.CovidStatus", "EmployeId");
            RenameColumn(table: "dbo.CovidStatus", name: "Employe_Id", newName: "EmployeId");
            DropPrimaryKey("dbo.Employes");
            AlterColumn("dbo.CovidStatus", "EmployeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Employes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Employes", "Id");
            CreateIndex("dbo.CovidStatus", "EmployeId");
            AddForeignKey("dbo.CovidStatus", "EmployeId", "dbo.Employes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CovidStatus", "EmployeId", "dbo.Employes");
            DropIndex("dbo.CovidStatus", new[] { "EmployeId" });
            DropPrimaryKey("dbo.Employes");
            AlterColumn("dbo.Employes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CovidStatus", "EmployeId", c => c.Int());
            AddPrimaryKey("dbo.Employes", "Id");
            RenameColumn(table: "dbo.CovidStatus", name: "EmployeId", newName: "Employe_Id");
            AddColumn("dbo.CovidStatus", "EmployeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.CovidStatus", "Employe_Id");
            AddForeignKey("dbo.CovidStatus", "Employe_Id", "dbo.Employes", "Id");
        }
    }
}
