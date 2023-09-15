namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookingsValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "CustomerId", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "XrayType", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Bookings", "XrayDescription", c => c.String(maxLength: 255));
            AlterColumn("dbo.Bookings", "ReferralDoctorName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Bookings", "ReferralDoctorPhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Bookings", "XrayOutcomeDesc", c => c.String(maxLength: 255));
            AlterColumn("dbo.Bookings", "CustomerFeedback", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "CustomerFeedback", c => c.String());
            AlterColumn("dbo.Bookings", "XrayOutcomeDesc", c => c.String());
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.String());
            AlterColumn("dbo.Bookings", "ReferralDoctorPhone", c => c.String());
            AlterColumn("dbo.Bookings", "ReferralDoctorName", c => c.String());
            AlterColumn("dbo.Bookings", "XrayDescription", c => c.String());
            AlterColumn("dbo.Bookings", "XrayType", c => c.String());
            AlterColumn("dbo.Bookings", "CustomerId", c => c.String());
        }
    }
}
