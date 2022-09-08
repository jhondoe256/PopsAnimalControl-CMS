namespace PAC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDoctorRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.AspNetRoles (Id,Name) VALUES (NEWID(),'Doctor')");
        }
        
        public override void Down()
        {
        }
    }
}
