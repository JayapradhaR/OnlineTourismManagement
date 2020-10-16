namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiftCardOrders", "CardId", "dbo.GiftCards");
            DropPrimaryKey("dbo.GiftCardOrders");
            AddColumn("dbo.GiftCardOrders", "GiftCardOrderId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GiftCardOrders", "GiftCardOrderId");
            AddForeignKey("dbo.GiftCardOrders", "CardId", "dbo.GiftCards", "CardId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiftCardOrders", "CardId", "dbo.GiftCards");
            DropPrimaryKey("dbo.GiftCardOrders");
            DropColumn("dbo.GiftCardOrders", "GiftCardOrderId");
            AddPrimaryKey("dbo.GiftCardOrders", "CardId");
            AddForeignKey("dbo.GiftCardOrders", "CardId", "dbo.GiftCards", "CardId");
        }
    }
}
