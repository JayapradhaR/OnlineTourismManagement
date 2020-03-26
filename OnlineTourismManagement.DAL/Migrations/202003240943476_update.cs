namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Gender", c => c.String(nullable: false, maxLength: 6));
            AlterStoredProcedure(
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
                    @"INSERT [dbo].[Customer]([FirstName], [LastName], [MobileNumber], [Gender], [DateOfBirth], [Username], [Password], [Role])
                      VALUES (@FirstName, @LastName, @MobileNumber, @Gender, @DateOfBirth, @Username, @Password, @Role)
                      
                      DECLARE @UserId int
                      SELECT @UserId = [UserId]
                      FROM [dbo].[Customer]
                      WHERE @@ROWCOUNT > 0 AND [UserId] = scope_identity()
                      
                      SELECT t0.[UserId]
                      FROM [dbo].[Customer] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UserId] = @UserId"
            );
            
            AlterStoredProcedure(
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
                    @"UPDATE [dbo].[Customer]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [MobileNumber] = @MobileNumber, [Gender] = @Gender, [DateOfBirth] = @DateOfBirth, [Username] = @Username, [Password] = @Password, [Role] = @Role
                      WHERE ([UserId] = @UserId)"
            );
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Gender", c => c.String(nullable: false, maxLength: 5));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
