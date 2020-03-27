namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItineraryColumnUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itineraries", "HotelLocation", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Itineraries", "HotelLocation");
        }
    }
}
