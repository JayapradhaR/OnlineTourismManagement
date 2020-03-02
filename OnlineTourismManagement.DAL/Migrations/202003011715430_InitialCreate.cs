namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageId = c.Int(name: "Package Id", nullable: false, identity: true),
                        PackageName = c.String(name: "Package Name", nullable: false),
                        PackageType = c.String(name: "Package Type", nullable: false),
                        CreationDate = c.DateTime(name: "Creation Date", nullable: false),
                        UpdationDate = c.DateTime(name: "Updation Date", nullable: false),
                        PackagePrice = c.Int(name: "Package Price", nullable: false),
                    })
                .PrimaryKey(t => t.PackageId);
            
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
            DropIndex("dbo.Customer", new[] { "Username" });
            DropTable("dbo.Customer");
            DropTable("dbo.Package");
        }
    }
}
