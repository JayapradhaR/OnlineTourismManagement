namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itinerary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itineraries", "ImageSource", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Itineraries", "ImageSource");
        }
    }
}
