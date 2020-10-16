namespace OnlineTourismManagement.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GiftCardOrders",
                c => new
                    {
                        CardId = c.Int(nullable: false),
                        Denomination = c.Long(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SenderName = c.String(nullable: false, maxLength: 100),
                        SenderMailId = c.String(nullable: false, maxLength: 64),
                        SenderMobileNumber = c.Long(nullable: false),
                        ReceiverName = c.String(nullable: false, maxLength: 100),
                        ReceiverMailId = c.String(nullable: false, maxLength: 64),
                        ConfirmReceiverMailId = c.String(nullable: false, maxLength: 64),
                        ReceiverMobileNumber = c.Long(nullable: false),
                        CardNumber = c.String(nullable: false, maxLength: 100),
                        PinNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.GiftCards", t => t.CardId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.GiftCards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CardId)
                .Index(t => t.CardName, unique: true);
            
            CreateTable(
                "dbo.GiftCardTypes",
                c => new
                    {
                        GiftCardTypeId = c.Int(nullable: false, identity: true),
                        GiftCardTypeName = c.String(nullable: false, maxLength: 40),
                        ImageSource = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GiftCardTypeId)
                .Index(t => t.GiftCardTypeName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiftCardOrders", "CardId", "dbo.GiftCards");
            DropIndex("dbo.GiftCardTypes", new[] { "GiftCardTypeName" });
            DropIndex("dbo.GiftCards", new[] { "CardName" });
            DropIndex("dbo.GiftCardOrders", new[] { "CardId" });
            DropTable("dbo.GiftCardTypes");
            DropTable("dbo.GiftCards");
            DropTable("dbo.GiftCardOrders");
        }
    }
}
