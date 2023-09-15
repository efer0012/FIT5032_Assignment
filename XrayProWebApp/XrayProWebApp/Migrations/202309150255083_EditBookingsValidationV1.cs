namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookingsValidationV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "XrayDescription", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "BookingStatus", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Bookings", "XrayDescription", c => c.String(maxLength: 255));
        }
    }
}
