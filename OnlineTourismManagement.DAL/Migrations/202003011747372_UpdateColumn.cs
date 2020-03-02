namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateColumn : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Package", name: "Package Id", newName: "PackageId");
            RenameColumn(table: "dbo.Package", name: "Package Name", newName: "PackageName");
            RenameColumn(table: "dbo.Package", name: "Package Type", newName: "PackageType");
            RenameColumn(table: "dbo.Package", name: "Creation Date", newName: "CreationDate");
            RenameColumn(table: "dbo.Package", name: "Updation Date", newName: "UpdationDate");
            RenameColumn(table: "dbo.Package", name: "Package Price", newName: "PackagePrice");
            AlterColumn("dbo.Package", "PackageName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Package", "PackageType", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Package", "PackageType", c => c.String(nullable: false));
            AlterColumn("dbo.Package", "PackageName", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Package", name: "PackagePrice", newName: "Package Price");
            RenameColumn(table: "dbo.Package", name: "UpdationDate", newName: "Updation Date");
            RenameColumn(table: "dbo.Package", name: "CreationDate", newName: "Creation Date");
            RenameColumn(table: "dbo.Package", name: "PackageType", newName: "Package Type");
            RenameColumn(table: "dbo.Package", name: "PackageName", newName: "Package Name");
            RenameColumn(table: "dbo.Package", name: "PackageId", newName: "Package Id");
        }
    }
}
