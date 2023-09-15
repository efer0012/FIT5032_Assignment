namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePhonenumberTypo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "PhoneNfumber", newName: "PhoneNumber");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "PhoneNumber", newName: "PhoneNfumber");
        }
    }
}
