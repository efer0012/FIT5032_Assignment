namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookingsImagesRoomsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CustomerId = c.String(),
                        RoomId = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        XrayType = c.String(),
                        XrayDescription = c.String(),
                        ReferralDoctorName = c.String(),
                        ReferralDoctorPhone = c.String(),
                        BookingStatus = c.String(),
                        XrayOutcomeDesc = c.String(),
                        NurseId = c.Int(),
                        CustomerRatings = c.Int(),
                        CustomerFeedback = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BookingId = c.String(maxLength: 128),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Images", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Images", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Images");
            DropTable("dbo.Bookings");
        }
    }
}
