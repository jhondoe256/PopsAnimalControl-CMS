using PAC.Data.Animals.Breeds;
using PAC.Models.AnimalModels.BreedModels.DogBreeds;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.BreedServices.DogBreedServices
{
    public class DogBreedService
    {
        private Guid _userId;
        public DogBreedService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<DogBreedListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breeds =
                    await
                    ctx
                    .Breeds
                   // .Where(b => b.OwnerID == _userId)
                    .Select(b => new DogBreedListItem
                    {
                        BreedID=b.BreedID,
                        BreedName=b.BreedName

                    }).ToListAsync();
                return breeds;
            }
        }
        public async Task<DogBreedDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breed =
                    await
                    ctx
                    .Breeds
              //      .Where(b => b.OwnerID == _userId)
                    .SingleOrDefaultAsync(b => b.BreedID == id);
                if (breed is null)
                {
                    return null;
                }
                return new DogBreedDetail
                {
                    BreedID=breed.BreedID,
                    BreedName=breed.BreedName,
                    Country=breed.Country,
                    Section=breed.Section
                };
                   
            }
        }
        public async Task<bool> Post(DogBreedCreate dogBreed)
        {
            var entity = new Breed
            {
                OwnerID=_userId,
                BreedName=dogBreed.BreedName,
                Country=dogBreed.Country,
                Section=dogBreed.Section
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Breeds.Add(entity);
               return await ctx.SaveChangesAsync() > 0;

            }
        }
        public async Task<bool> Put(DogBreedEdit dogBreed, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breed =
                    await
                    ctx
                    .Breeds
                    .Where(b => b.OwnerID == _userId)
                    .SingleOrDefaultAsync(b => b.BreedID == id);
                if (breed is null)
                {
                    return false;
                }

                breed.BreedName = dogBreed.BreedName;
                breed.Country = dogBreed.Country;
                breed.Section = dogBreed.Section;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breed =
                   await
                   ctx
                   .Breeds
                   .Where(b => b.OwnerID == _userId)
                   .SingleOrDefaultAsync(b => b.BreedID == id);
                if (breed is null)
                {
                    return false;
                }

                ctx.Breeds.Remove(breed);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
