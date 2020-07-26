namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Itineraries", "Location", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Itineraries", "DetailedItinerary", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Itineraries", "DetailedItinerary");
            DropColumn("dbo.Itineraries", "Location");
        }
    }
}
