namespace PAC.Data.Migrations
{
    using PAC.Data.Utilities.BreedUitilities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PopsAnimalControl.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PopsAnimalControl.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var listOfBreeds = CsvReaderDogBreeds.ReadAllBreeds().OrderBy(b => b.BreedName);

            context.Breeds.AddOrUpdate(b => b.BreedName, listOfBreeds.ToArray());
        }
    }
}
