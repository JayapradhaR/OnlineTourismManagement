namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Package", new[] { "PackageName" });
            AlterColumn("dbo.Package", "PackageName", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Package", "PackageName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Package", new[] { "PackageName" });
            AlterColumn("dbo.Package", "PackageName", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Package", "PackageName", unique: true);
        }
    }
}
