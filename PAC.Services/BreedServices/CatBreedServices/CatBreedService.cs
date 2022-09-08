using PAC.Data.Animals.Breeds;
using PAC.Models.AnimalModels.BreedModels.CatBreeds;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.BreedServices.CatBreedServices
{
    public class CatBreedService
    {
        private readonly Guid _userId;
        public CatBreedService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<CatBreedListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breeds =
                    await
                    ctx
                    .CatBreedTypes
      //              .Where(c => c.OwnerID == _userId)
                    .Select(c => new CatBreedListItem
                    {
                        Cat_BreedID=c.ID,
                        BreedName=c.BreedName
                    }).ToListAsync();

                return breeds;
            }
        }
        public async Task<CatBreedDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var breed =
                    await
                    ctx
                    .CatBreedTypes
        //            .Where(c => c.OwnerID == _userId)
                    .SingleOrDefaultAsync(c => c.ID == id);
                if (breed is null)
                {
                    return null;
                }
                return new CatBreedDetail
                {
                    Cat_BreedID=breed.ID,
                    Breed=breed.BreedName,
                    LocationAndOrigin=breed.LocationAndOrigin,
                    Type=breed.Type,
                    BodyType=breed.BodyType,
                    CoatTypeAndLength=breed.CoatTypeAndLength,
                    CoatPattern=breed.CoatPattern
                };
            }
        }
        public async Task<bool> Post(CatBreedCreate catBreed)
        {
            var entity = new CatBreedType
            {
                OwnerID=_userId,
                BreedName=catBreed.Breed,
                LocationAndOrigin=catBreed.LocationAndOrigin,
                Type=catBreed.Type,
                BodyType=catBreed.BodyType,
                CoatTypeAndLength=catBreed.CoatTypeAndLength,
                CoatPattern=catBreed.CoatPattern
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.CatBreedTypes.Add(entity);
                return await ctx.SaveChangesAsync()>0;
            }
        }
        public async Task<bool> Put(CatBreedEdit catBreed, int id) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldBreedData = await ctx.CatBreedTypes.Where(c => c.OwnerID == _userId).SingleOrDefaultAsync(c => c.ID == id);
                if (oldBreedData is null)
                {
                    return false;
                }
                oldBreedData.BreedName = catBreed.Breed;
                oldBreedData.LocationAndOrigin = catBreed.LocationAndOrigin;
                oldBreedData.Type = catBreed.Type;
                oldBreedData.BodyType = catBreed.BodyType;
                oldBreedData.CoatTypeAndLength = catBreed.CoatTypeAndLength;
                oldBreedData.CoatPattern = catBreed.CoatPattern;

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
                    .CatBreedTypes
            //        .Where(c => c.OwnerID == _userId)
                    .SingleOrDefaultAsync(c => c.ID == id);

                if (breed is null)
                {
                    return false;
                }
                ctx.CatBreedTypes.Remove(breed);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
