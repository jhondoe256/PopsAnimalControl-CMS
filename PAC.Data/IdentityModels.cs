using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PAC.Data.Animals.Breeds;
using PAC.Data.Animals.Cats;
using PAC.Data.Animals.Dogs;
using PAC.Data.Animals.Pokemon;
using PAC.Data.CatCatchers;
using PAC.Data.Contracts.IEmployees;
using PAC.Data.Contracts.IReports;
using PAC.Data.Contracts.VetTechs;
using PAC.Data.Departments;
using PAC.Data.DogCatchers;
using PAC.Data.Employees;
using PAC.Data.Employees.Applicants;
using PAC.Data.Employees.Applicants.Applicant_References;
using PAC.Data.Employees.Applicants.References;
using PAC.Data.Employees.HouesKeepers;
using PAC.Data.Employees.Positions;
using PAC.Data.HumanResource_s;
using PAC.Data.HumanResource_s.HiredEmployee_s;
using PAC.Data.Managers;
using PAC.Data.PokemonCatchers;
using PAC.Data.Reports;
using PAC.Data.Reports.CatReports;
using PAC.Data.Reports.DogReports;
using PAC.Data.Reports.PokemonReports;
using PAC.Data.Secretaries;
using PAC.Data.TerminatedEmployees;
using PAC.Data.Veterinarians;

namespace PopsAnimalControl.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<PokemonCatcher> PokemonCatchers { get; set; }
        public DbSet<TerminatedEmployee> TerminatedEmployees { get; set; }
        public DbSet<HumanResources> HumanResources { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<VetTech> VetTechs{ get; set; }
        public DbSet<DogCatcher> DogCatchers{ get; set; }
        public DbSet<CatCatcher> CatCatchers{ get; set; }
        public DbSet<Secretary> Secretaries{ get; set; }
        public DbSet<HouseKeeper> HouseKeepers{ get; set; }
        public DbSet<Applicant> Applicants{ get; set; }
        public DbSet<Position> Positions{ get; set; }
        public DbSet<Department> Departments{ get; set; }
        public DbSet<DogReport> DogReports{ get; set; }
        public DbSet<CatBreedType> CatBreedTypes { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<PokemonReport> PokemonReports { get; set; }
        public DbSet<Dog> Dogs{ get; set; }
        public DbSet<CatReport> catReports { get; set; }
        public DbSet<HiredEmployee> HiredEmployees{ get; set; }
        public DbSet<Applicant_Reference> Applicant_References{ get; set; }
        public DbSet<Reference> References{ get; set; }
        public DbSet<Pokemon> Pokemons{ get; set; }
    }

 
}