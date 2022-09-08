namespace PAC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmailAddressToApplicantTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "EmailAddress");
        }
    }
}
