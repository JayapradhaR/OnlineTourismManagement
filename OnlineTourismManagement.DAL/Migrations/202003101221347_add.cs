namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        PackageTypeId = c.Int(nullable: false),
                        PackageName = c.String(nullable: false, maxLength: 30),
                        Duration = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdationDate = c.DateTime(nullable: false),
                        PackagePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PackageId)
                .ForeignKey("dbo.PackageTypes", t => t.PackageTypeId, cascadeDelete: true)
                .Index(t => t.PackageTypeId)
                .Index(t => t.PackageName, unique: true);
            
            CreateTable(
                "dbo.PackageTypes",
                c => new
                    {
                        PackageTypeId = c.Int(nullable: false, identity: true),
                        PackageTypeName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.PackageTypeId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        MobileNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Package", "PackageTypeId", "dbo.PackageTypes");
            DropIndex("dbo.Customer", new[] { "Username" });
            DropIndex("dbo.Package", new[] { "PackageName" });
            DropIndex("dbo.Package", new[] { "PackageTypeId" });
            DropTable("dbo.Customer");
            DropTable("dbo.PackageTypes");
            DropTable("dbo.Package");
        }
    }
}
