namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Package", "ImageSource", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Package", "ImageSource");
        }
    }
}
