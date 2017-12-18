namespace EFDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changing_phonenumber_to_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.Int());
        }
    }
}
