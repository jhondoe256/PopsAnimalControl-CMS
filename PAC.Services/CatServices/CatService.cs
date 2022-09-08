using PAC.Data.Animals.Cats;
using PAC.Models.AnimalModels.BreedModels.CatBreeds;
using PAC.Models.AnimalModels.CatModels;
using PAC.Models.ReportModels.CatReportModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.CatServices
{
    public class CatService
    {
        private readonly Guid _userId;
        public CatService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<CatListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cats =
                    await
                    ctx
                    .Cats
               //     .Where(c => c.OwnerID == _userId)
                    .Select(c => new CatListItem
                    {
                        ID=c.ID,
                        Name=c.Name
                    }).ToListAsync();
                return cats;
            }
        }
        public async Task<CatDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cat =
                    await
                    ctx
                    .Cats
                  //  .Where(c => c.OwnerID == _userId)
                    .SingleOrDefaultAsync(c => c.ID == id);
                if (cat is null)
                {
                    return null;
                }

                var breed = ctx.CatBreedTypes.SingleOrDefault(b => b.ID == cat.CatBreedID);
                var report = ctx.catReports.SingleOrDefault(c => c.Name == cat.Name);
                return new CatDetail
                {
                    ID=cat.ID,
                    Name=cat.Name,
                    Breed=new CatBreedListItem 
                    {
                        Cat_BreedID=breed.ID,
                        BreedName=breed.BreedName
                    },
                    DateOfBirth=cat.DateOfBirth,
                    Age=cat.Age,
                    CatReport= new CatReportListItem 
                    {
                        ReportID=report.ReportID,
                        EmployeeID=report.EmployeeID,
                        EmployeeFirstName=report.FirstName,
                        EmployeeLastName=report.LastName,
                        CreationDate=report.CreationDate,
                    },
                    HasChipIdentification=cat.HasChipIdentification,
                    HasCollarIdentification=cat.HasCollarIdentification,
                    InjurySeverityType=cat.InjurySeverityType,
                    TempermentType=cat.TempermentType,
                    CaptureWorth=cat.CaptureWorth,
                    DateOfCapture=cat.DateOfCapture
                };
            }
        }
        public async Task<bool> Post(CatCreate cat)
        {
            var entity = new Cat
            {
                OwnerID = _userId,
                Name=cat.Name,
                CatBreedID=cat.CatBreedID,
                HasChipIdentification=cat.HasChipIdentification,
                HasCollarIdentification=cat.HasCollarIdentification,
                DateOfBirth=cat.DateOfBirth,
                CaptureWorth=cat.CaptureWorth,
                InjurySeverityType=cat.InjurySeverityType,
                TempermentType=cat.TempermentType,
                DateOfCapture=DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                var breedType =await ctx.CatBreedTypes.Where(c => c.OwnerID == _userId).SingleOrDefaultAsync(c => c.ID == cat.CatBreedID);
                if (breedType is null)
                {
                    return false;
                }

                entity.CatBreedType = breedType;

                ctx.Cats.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Put(CatEdit cat, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldCatData = await ctx.Cats.Where(c => c.OwnerID == _userId).SingleOrDefaultAsync(c => c.ID == id);
                if (oldCatData is null)
                {
                    return false;
                }
                oldCatData.Name = cat.Name;
                oldCatData.DateOfBirth = cat.DateOfBirth;
                oldCatData.HasChipIdentification = cat.HasChipIdentification;
                oldCatData.HasCollarIdentification = cat.HasCollarIdentification;
                oldCatData.InjurySeverityType = cat.InjurySeverityType;
                oldCatData.TempermentType = cat.TempermentType;
                oldCatData.CaptureWorth = cat.CaptureWorth;
                oldCatData.DateOfCapture = cat.DateOfCapture;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var cat =
                    await
                    ctx
                    .Cats
                    .Where(c => c.OwnerID == _userId)
                    .SingleOrDefaultAsync(c => c.ID == id);
                if (cat is null)
                {
                    return false;
                }
                ctx.Cats.Remove(cat);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
