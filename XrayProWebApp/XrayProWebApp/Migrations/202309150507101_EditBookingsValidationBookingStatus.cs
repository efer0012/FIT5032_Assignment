namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookingsValidationBookingStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.String(maxLength: 20));
        }
    }
}
