namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Package", new[] { "PackageId" });
            CreateIndex("dbo.Package", "PackageName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Package", new[] { "PackageName" });
            CreateIndex("dbo.Package", "PackageId", unique: true);
        }
    }
}
