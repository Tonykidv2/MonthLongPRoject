namespace EFDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.EducationID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.Int(),
                        Email = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        IsMale = c.Boolean(nullable: false),
                        State = c.Int(nullable: false),
                        Name = c.String(),
                        State1_StateID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.States", t => t.State1_StateID)
                .Index(t => t.State1_StateID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.EmployeeEducations",
                c => new
                    {
                        Employee_EmployeeID = c.Int(nullable: false),
                        Education_EducationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeID, t.Education_EducationID })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Educations", t => t.Education_EducationID, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeID)
                .Index(t => t.Education_EducationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "State1_StateID", "dbo.States");
            DropForeignKey("dbo.EmployeeEducations", "Education_EducationID", "dbo.Educations");
            DropForeignKey("dbo.EmployeeEducations", "Employee_EmployeeID", "dbo.Employees");
            DropIndex("dbo.EmployeeEducations", new[] { "Education_EducationID" });
            DropIndex("dbo.EmployeeEducations", new[] { "Employee_EmployeeID" });
            DropIndex("dbo.Employees", new[] { "State1_StateID" });
            DropTable("dbo.EmployeeEducations");
            DropTable("dbo.States");
            DropTable("dbo.Employees");
            DropTable("dbo.Educations");
        }
    }
}
