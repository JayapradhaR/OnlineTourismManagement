namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PackageTypes", "ImageSource", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PackageTypes", "ImageSource");
        }
    }
}
