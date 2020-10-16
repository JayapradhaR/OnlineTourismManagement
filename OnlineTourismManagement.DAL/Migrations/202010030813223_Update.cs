namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Itineraries",
                c => new
                    {
                        ItineraryId = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(nullable: false),
                        DayName = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 50),
                        HotelName = c.String(nullable: false, maxLength: 30),
                        HotelLocation = c.String(nullable: false, maxLength: 50),
                        SightSeeing = c.String(nullable: false, maxLength: 30),
                        Meal = c.String(nullable: false, maxLength: 20),
                        ImageSource = c.String(nullable: false),
                        DetailedItinerary = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ItineraryId)
                .ForeignKey("dbo.Package", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        PackageTypeId = c.Int(nullable: false),
                        PackageName = c.String(nullable: false, maxLength: 100),
                        Duration = c.Int(nullable: false),
                        Availability = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        UpdationDate = c.DateTime(nullable: false),
                        ImageSource = c.String(nullable: false),
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
                        ImageSource = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PackageTypeId)
                .Index(t => t.PackageTypeName, unique: true);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        UserMailId = c.String(nullable: false, maxLength: 64),
                        Name = c.String(nullable: false, maxLength: 120),
                        FromDate = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        AdultsCount = c.Int(nullable: false),
                        ChildrensCount = c.Int(nullable: false),
                        MobileNumber = c.Long(nullable: false),
                        PackageId = c.Int(nullable: false),
                        PackagePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Package", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        MobileNumber = c.Long(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 6),
                        DateOfBirth = c.DateTime(nullable: false),
                        Username = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Username, unique: true);
            
            CreateStoredProcedure(
                "dbo.sp_InsertUser",
                p => new
                    {
                        FirstName = p.String(maxLength: 30),
                        LastName = p.String(maxLength: 30),
                        MobileNumber = p.Long(),
                        Gender = p.String(maxLength: 6),
                        DateOfBirth = p.DateTime(),
                        Username = p.String(maxLength: 64),
                        Password = p.String(maxLength: 20),
                        Role = p.String(maxLength: 10),
                    },
                body:
                    @"INSERT [dbo].[Customers]([FirstName], [LastName], [MobileNumber], [Gender], [DateOfBirth], [Username], [Password], [Role])
                      VALUES (@FirstName, @LastName, @MobileNumber, @Gender, @DateOfBirth, @Username, @Password, @Role)
                      
                      DECLARE @UserId int
                      SELECT @UserId = [UserId]
                      FROM [dbo].[Customers]
                      WHERE @@ROWCOUNT > 0 AND [UserId] = scope_identity()
                      
                      SELECT t0.[UserId]
                      FROM [dbo].[Customers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UserId] = @UserId"
            );
            
            CreateStoredProcedure(
                "dbo.sp_UpdateUser",
                p => new
                    {
                        UserId = p.Int(),
                        FirstName = p.String(maxLength: 30),
                        LastName = p.String(maxLength: 30),
                        MobileNumber = p.Long(),
                        Gender = p.String(maxLength: 6),
                        DateOfBirth = p.DateTime(),
                        Username = p.String(maxLength: 64),
                        Password = p.String(maxLength: 20),
                        Role = p.String(maxLength: 10),
                    },
                body:
                    @"UPDATE [dbo].[Customers]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [MobileNumber] = @MobileNumber, [Gender] = @Gender, [DateOfBirth] = @DateOfBirth, [Username] = @Username, [Password] = @Password, [Role] = @Role
                      WHERE ([UserId] = @UserId)"
            );
            
            CreateStoredProcedure(
                "dbo.sp_DeleteUser",
                p => new
                    {
                        UserId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Customers]
                      WHERE ([UserId] = @UserId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.sp_DeleteUser");
            DropStoredProcedure("dbo.sp_UpdateUser");
            DropStoredProcedure("dbo.sp_InsertUser");
            DropForeignKey("dbo.Orders", "PackageId", "dbo.Package");
            DropForeignKey("dbo.Itineraries", "PackageId", "dbo.Package");
            DropForeignKey("dbo.Package", "PackageTypeId", "dbo.PackageTypes");
            DropIndex("dbo.Customers", new[] { "Username" });
            DropIndex("dbo.Orders", new[] { "PackageId" });
            DropIndex("dbo.PackageTypes", new[] { "PackageTypeName" });
            DropIndex("dbo.Package", new[] { "PackageName" });
            DropIndex("dbo.Package", new[] { "PackageTypeId" });
            DropIndex("dbo.Itineraries", new[] { "PackageId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.PackageTypes");
            DropTable("dbo.Package");
            DropTable("dbo.Itineraries");
        }
    }
}
