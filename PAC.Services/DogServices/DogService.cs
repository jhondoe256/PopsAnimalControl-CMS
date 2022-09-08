using PAC.Data.Animals.Dogs;
using PAC.Models.AnimalModels.BreedModels.DogBreeds;
using PAC.Models.DogModels;
using PAC.Models.ReportModels.DogReportModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.DogServices
{
    public class DogService
    {
        private readonly Guid _userId;
        public DogService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<DogListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dogs =
                    await
                    ctx
                    .Dogs
              //      .Where(d => d.OwnerID == _userId)
                    .Select(d => new DogListItem
                    {
                        ID=d.ID,
                        Name=(d.Name==null)?"Unidentiified Dog":d.Name
                    }).ToListAsync();
                return dogs;
            }
        }
        public async Task<DogDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dog = await
                    ctx
                    .Dogs
                    .Include(d=>d.Breed)
                  //  .Where(d => d.OwnerID == _userId)
                    .SingleOrDefaultAsync(d => d.ID == id);
                if (dog is null)
                {
                    return null;
                }

                var report = ctx.DogReports.FirstOrDefault(d => d.Name == dog.Name);
                if (report is null)
                {
                    return null;
                }
                var employee = await ctx.Employees.SingleOrDefaultAsync(e => e.EmployeeID == report.EmployeeID);
                if (employee is null)
                {
                    return null;
                }
                var breed = await ctx.Breeds.SingleOrDefaultAsync(b => b.BreedID == dog.BreedID);
                if (breed is null)
                {
                    return null;
                }
                return new DogDetail
                {
                    ID = dog.ID,
                    Name = dog.Name,
                    Age = dog.Age,
                    DateOfBirth = dog.DateOfBirth,
                    DateOfCapture = dog.DateOfCapture,
                    BreedID = dog.BreedID,
                    Breed = new DogBreedListItem 
                    {
                        BreedID=breed.BreedID,
                        BreedName=breed.BreedName
                    },
                    HasChipIdentification = dog.HasChipIdentification,
                    HasCollarIdentification = dog.HasCollarIdentification,
                    InjuryServerityType = dog.InjurySeverityType.ToString(),
                    TempermentType = dog.TempermentType.ToString(),
                    CaptureWorth = dog.CaptureWorth,
                    DogReport = new DogReportListItem
                    {
                        ReportID = report.ReportID,
                        EmployeeID=employee.EmployeeID,
                        EmployeeFirstName = employee.FirstName,
                        EmployeeLastName=employee.LastName,
                        CreationDate=report.CreationDate
                    } 
                };
            }
        }
        public async Task<bool> Post(DogCreate dog)
        {
            var entity = new Dog
            {
                OwnerID = _userId,
                Name = dog.Name,
                BreedID = dog.BreedID,
                DateOfBirth = dog.DateOfBirth,
                DateOfCapture = DateTime.Now,
                HasCollarIdentification = dog.HasCollarIdentification,
                HasChipIdentification = dog.HasChipIdentification,
                CaptureWorth = dog.CaptureWorth,
                InjurySeverityType = dog.InjurtServerityType,
                TempermentType = dog.TempermentType
            };

            using (var ctx = new ApplicationDbContext())
            {
                var breed = await ctx.Breeds.FindAsync(dog.BreedID);
                if (breed is null)
                {
                    return false;
                }

                entity.Breed = breed;

                ctx.Dogs.Add(entity);

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Put(DogEdit dog, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldDogData = await ctx.Dogs.Where(c => c.OwnerID == _userId).SingleOrDefaultAsync(d => d.ID == id);
                if (oldDogData is null)
                {
                    return false;
                }
                oldDogData.Name = dog.Name;
                oldDogData.DateOfBirth = dog.DateOfBirth;
                oldDogData.DateOfCapture = dog.DateOfCapture;
                oldDogData.HasChipIdentification = dog.HasChipIdentification;
                oldDogData.HasCollarIdentification = dog.HasCollarIdentification;
                oldDogData.TempermentType = dog.TempermentType;
                oldDogData.InjurySeverityType = dog.InjuryServerityType;

                var breed = await ctx.Breeds.FindAsync(dog.BreedID);
                if (breed is null)
                {
                    breed = null;
                }
                oldDogData.Breed = breed;

                var report = await ctx.DogReports.FindAsync(dog.ReportID);
                if (report is null)
                {
                    report = null;
                }
                //This may be changed.....
                report.HasChipIdentification = oldDogData.HasChipIdentification;
                report.HasCollarIdentification = oldDogData.HasCollarIdentification;
                report.Breed = oldDogData.Breed;
                report.Name = oldDogData.Name;
                report.DateOfBirth = oldDogData.DateOfBirth;
                report.DateOfCapture = oldDogData.DateOfCapture;
                report.TempermentType = oldDogData.TempermentType;
                report.InjurySeverityType = oldDogData.InjurySeverityType;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var dog =
                    await
                    ctx
                    .Dogs
                    .Where(d => d.OwnerID == _userId)
                    .FirstOrDefaultAsync(d => d.ID == id);

                if (dog is null)
                {
                    return false;
                }
               
                ctx.Dogs.Remove(dog);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<IEnumerable<DogListItem>> GetDogFromSearch(string value)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = await ctx.Dogs.Where(x => x.Name.Contains(value)).Select(x=> new DogListItem 
                {
                    ID=x.ID,
                    Name=x.Name
                }).ToListAsync();
                return query;
            }
        }
    }
}
