namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Package", "PackageId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Package", new[] { "PackageId" });
        }
    }
}
