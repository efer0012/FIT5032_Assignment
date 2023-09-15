namespace XrayProWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewAttributesToUsers : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "PhoneNumber", newName: "PhoneNfumber");
            AddColumn("dbo.AspNetUsers", "First_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Last_name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Street_number", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "Suburb", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNfumber", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNfumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Suburb");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "Street_number");
            DropColumn("dbo.AspNetUsers", "Dob");
            DropColumn("dbo.AspNetUsers", "Last_name");
            DropColumn("dbo.AspNetUsers", "First_name");
            RenameColumn(table: "dbo.AspNetUsers", name: "PhoneNfumber", newName: "PhoneNumber");
        }
    }
}
