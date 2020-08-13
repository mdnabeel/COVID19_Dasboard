namespace Covid19_Dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CovidCategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CovidStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        CovidCategoryId = c.Byte(nullable: false),
                        DutyPlaceId = c.Byte(nullable: false),
                        EmployeId = c.Byte(nullable: false),
                        CovidPositiveAt500M = c.Int(nullable: false),
                        CovidPositiveAt1KM = c.Int(nullable: false),
                        CovidPositiveAt2KM = c.Int(nullable: false),
                        CovidPositiveAt5KM = c.Int(nullable: false),
                        CovidPositiveAt10KM = c.Int(nullable: false),
                        AnythingReported = c.String(),
                        Employe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CovidCategories", t => t.CovidCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.DutyPlaces", t => t.DutyPlaceId, cascadeDelete: true)
                .ForeignKey("dbo.Employes", t => t.Employe_Id)
                .Index(t => t.CovidCategoryId)
                .Index(t => t.DutyPlaceId)
                .Index(t => t.Employe_Id);
            
            CreateTable(
                "dbo.DutyPlaces",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        PlaceOfDuty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmpID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CovidStatus", "Employe_Id", "dbo.Employes");
            DropForeignKey("dbo.CovidStatus", "DutyPlaceId", "dbo.DutyPlaces");
            DropForeignKey("dbo.CovidStatus", "CovidCategoryId", "dbo.CovidCategories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CovidStatus", new[] { "Employe_Id" });
            DropIndex("dbo.CovidStatus", new[] { "DutyPlaceId" });
            DropIndex("dbo.CovidStatus", new[] { "CovidCategoryId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employes");
            DropTable("dbo.DutyPlaces");
            DropTable("dbo.CovidStatus");
            DropTable("dbo.CovidCategories");
        }
    }
}
