namespace PAC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant_Reference",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ApplicantID = c.Int(nullable: false),
                        ReferenceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID, cascadeDelete: true)
                .ForeignKey("dbo.References", t => t.ReferenceID, cascadeDelete: true)
                .Index(t => t.ApplicantID)
                .Index(t => t.ReferenceID);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        SocialSecurityNumber = c.String(maxLength: 11),
                        CompanyAName = c.String(maxLength: 200),
                        CompanyAReferenceFirstName = c.String(maxLength: 200),
                        CompanyAReferenceLastName = c.String(maxLength: 200),
                        CompanyAAddress = c.String(maxLength: 400),
                        CompanyADateStarted = c.DateTime(),
                        CompanyADateEnded = c.DateTime(),
                        CompanyAMayWeContactThisEmployer = c.Boolean(nullable: false),
                        CompanyBName = c.String(maxLength: 200),
                        CompanyBReferenceFirstName = c.String(maxLength: 200),
                        CompanyBReferenceLastName = c.String(maxLength: 200),
                        CompanyBAddress = c.String(maxLength: 400),
                        CompanyBDateStarted = c.DateTime(),
                        CompanyBDateEnded = c.DateTime(),
                        CompanyBMayWeContactThisEmployer = c.Boolean(nullable: false),
                        CompanyCName = c.String(maxLength: 200),
                        CompanyCReferenceFirstName = c.String(maxLength: 200),
                        CompanyCReferenceLastName = c.String(maxLength: 200),
                        CompanyCAddress = c.String(maxLength: 400),
                        CompanyCDateStarted = c.DateTime(),
                        CompanyCDateEnded = c.DateTime(),
                        CompanyCMayWeContactThisEmployer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationionDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        AvailablePositionCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PositionID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        ReferenceID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 200),
                        ReferenceFirstName = c.String(maxLength: 200),
                        ReferenceLastName = c.String(maxLength: 200),
                        Address = c.String(maxLength: 400),
                        DateStarted = c.DateTime(),
                        DateEnded = c.DateTime(),
                        MayWeContactThisEmployer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReferenceID);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        BreedID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        BreedName = c.String(nullable: false),
                        Section = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.BreedID);
            
            CreateTable(
                "dbo.CatBreedTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        BreedName = c.String(nullable: false),
                        LocationAndOrigin = c.String(),
                        Type = c.String(),
                        BodyType = c.String(),
                        CoatTypeAndLength = c.String(),
                        CoatPattern = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CatCatchers",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        isFired = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.CatReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CatBreedID = c.Int(nullable: false),
                        Name = c.String(),
                        EventDescription = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationionDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.CatBreedTypes", t => t.CatBreedID, cascadeDelete: true)
                .Index(t => t.CatBreedID);
            
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CatBreedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CatBreedTypes", t => t.CatBreedID, cascadeDelete: true)
                .Index(t => t.CatBreedID);
            
            CreateTable(
                "dbo.DogCatchers",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        isFired = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.DogReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BreedID = c.Int(nullable: false),
                        Name = c.String(),
                        EventDescription = c.String(),
                        EmployeeID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationionDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ReportID)
                .ForeignKey("dbo.Breeds", t => t.BreedID, cascadeDelete: true)
                .Index(t => t.BreedID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BreedID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breeds", t => t.BreedID, cascadeDelete: true)
                .Index(t => t.BreedID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.HiredEmployees",
                c => new
                    {
                        HireID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        EmployeeDateOfHire = c.DateTime(nullable: false),
                        HireableEmployeeCount = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.HireID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.HouseKeepers",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.HumanResources",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.PokemonCatchers",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        isFired = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        PositionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.PokemonReports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PokemonBirthName = c.String(),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        id = c.Int(nullable: false),
                        name = c.String(),
                        EventDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationionDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReportID);
            
            CreateTable(
                "dbo.Pokemons",
                c => new
                    {
                        PokeID = c.Int(nullable: false, identity: true),
                        PokemonBirthName = c.String(),
                        name = c.String(),
                        id = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(),
                        DateOfCapture = c.DateTime(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        TempermentType = c.Int(nullable: false),
                        InjurySeverityType = c.Int(nullable: false),
                        CaptureWorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PokeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Secretaries",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.TerminatedEmployees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfTermination = c.DateTime(nullable: false),
                        RehireableChances = c.Int(nullable: false),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Veterinarians",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
            CreateTable(
                "dbo.VetTeches",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PositionID = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModificationDate = c.DateTime(),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Positions", t => t.PositionID, cascadeDelete: true)
                .Index(t => t.PositionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VetTeches", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Veterinarians", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TerminatedEmployees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Secretaries", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PokemonCatchers", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Managers", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.HumanResources", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.HouseKeepers", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.HiredEmployees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.HiredEmployees", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Employees", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropForeignKey("dbo.DogReports", "BreedID", "dbo.Breeds");
            DropForeignKey("dbo.DogCatchers", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Cats", "CatBreedID", "dbo.CatBreedTypes");
            DropForeignKey("dbo.CatReports", "CatBreedID", "dbo.CatBreedTypes");
            DropForeignKey("dbo.CatCatchers", "PositionID", "dbo.Positions");
            DropForeignKey("dbo.Applicant_Reference", "ReferenceID", "dbo.References");
            DropForeignKey("dbo.Applicant_Reference", "ApplicantID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Positions", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.VetTeches", new[] { "PositionID" });
            DropIndex("dbo.Veterinarians", new[] { "PositionID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TerminatedEmployees", new[] { "PositionID" });
            DropIndex("dbo.Secretaries", new[] { "PositionID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PokemonCatchers", new[] { "PositionID" });
            DropIndex("dbo.Managers", new[] { "PositionID" });
            DropIndex("dbo.HumanResources", new[] { "PositionID" });
            DropIndex("dbo.HouseKeepers", new[] { "PositionID" });
            DropIndex("dbo.HiredEmployees", new[] { "DepartmentID" });
            DropIndex("dbo.HiredEmployees", new[] { "PositionID" });
            DropIndex("dbo.Employees", new[] { "PositionID" });
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            DropIndex("dbo.DogReports", new[] { "BreedID" });
            DropIndex("dbo.DogCatchers", new[] { "PositionID" });
            DropIndex("dbo.Cats", new[] { "CatBreedID" });
            DropIndex("dbo.CatReports", new[] { "CatBreedID" });
            DropIndex("dbo.CatCatchers", new[] { "PositionID" });
            DropIndex("dbo.Positions", new[] { "DepartmentID" });
            DropIndex("dbo.Applicants", new[] { "DepartmentID" });
            DropIndex("dbo.Applicant_Reference", new[] { "ReferenceID" });
            DropIndex("dbo.Applicant_Reference", new[] { "ApplicantID" });
            DropTable("dbo.VetTeches");
            DropTable("dbo.Veterinarians");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TerminatedEmployees");
            DropTable("dbo.Secretaries");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pokemons");
            DropTable("dbo.PokemonReports");
            DropTable("dbo.PokemonCatchers");
            DropTable("dbo.Managers");
            DropTable("dbo.HumanResources");
            DropTable("dbo.HouseKeepers");
            DropTable("dbo.HiredEmployees");
            DropTable("dbo.Employees");
            DropTable("dbo.Dogs");
            DropTable("dbo.DogReports");
            DropTable("dbo.DogCatchers");
            DropTable("dbo.Cats");
            DropTable("dbo.CatReports");
            DropTable("dbo.CatCatchers");
            DropTable("dbo.CatBreedTypes");
            DropTable("dbo.Breeds");
            DropTable("dbo.References");
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
            DropTable("dbo.Applicants");
            DropTable("dbo.Applicant_Reference");
        }
    }
}
