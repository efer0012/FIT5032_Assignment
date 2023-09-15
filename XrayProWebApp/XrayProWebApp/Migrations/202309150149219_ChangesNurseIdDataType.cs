namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesNurseIdDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "NurseId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "NurseId", c => c.Int());
        }
    }
}
