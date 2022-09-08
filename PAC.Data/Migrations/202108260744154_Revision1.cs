namespace PAC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revision1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CatCatchers", "ImageSource", c => c.String());
            AddColumn("dbo.DogCatchers", "ImageSource", c => c.String());
            AddColumn("dbo.Employees", "ImageSource", c => c.String());
            AddColumn("dbo.HiredEmployees", "ImageSource", c => c.String());
            AddColumn("dbo.HouseKeepers", "ImageSource", c => c.String());
            AddColumn("dbo.HumanResources", "ImageSource", c => c.String());
            AddColumn("dbo.Managers", "ImageSource", c => c.String());
            AddColumn("dbo.PokemonCatchers", "ImageSource", c => c.String());
            AddColumn("dbo.Secretaries", "ImageSource", c => c.String());
            AddColumn("dbo.TerminatedEmployees", "ImageSource", c => c.String());
            AddColumn("dbo.Veterinarians", "ImageSource", c => c.String());
            AddColumn("dbo.VetTeches", "ImageSource", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VetTeches", "ImageSource");
            DropColumn("dbo.Veterinarians", "ImageSource");
            DropColumn("dbo.TerminatedEmployees", "ImageSource");
            DropColumn("dbo.Secretaries", "ImageSource");
            DropColumn("dbo.PokemonCatchers", "ImageSource");
            DropColumn("dbo.Managers", "ImageSource");
            DropColumn("dbo.HumanResources", "ImageSource");
            DropColumn("dbo.HouseKeepers", "ImageSource");
            DropColumn("dbo.HiredEmployees", "ImageSource");
            DropColumn("dbo.Employees", "ImageSource");
            DropColumn("dbo.DogCatchers", "ImageSource");
            DropColumn("dbo.CatCatchers", "ImageSource");
        }
    }
}
