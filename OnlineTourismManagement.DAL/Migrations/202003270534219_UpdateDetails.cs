namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Role", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.PackageTypes", "PackageTypeName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PackageTypes", new[] { "PackageTypeName" });
            AlterColumn("dbo.Customer", "Role", c => c.String(maxLength: 10));
        }
    }
}
