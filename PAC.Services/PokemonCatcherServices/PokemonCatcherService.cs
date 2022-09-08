using PAC.Data.Employees;
using PAC.Data.PokemonCatchers;
using PAC.Models.PokemonCatcherModels;
using PAC.Models.PositionModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.PokemonCatcherServices
{
    public class PokemonCatcherService
    {
        private readonly Guid _userId;
        public PokemonCatcherService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<PokemonCatcherListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokeCatchers =
                     await
                     ctx
                     .PokemonCatchers
                     .Include(p => p.Position)
                     .Include(p => p.Position.Department)
                  //   .Where(p => p.OwnerID == _userId)
                     .Select(p => new PokemonCatcherListItem
                     {
                         EmployeeID = p.EmployeeID,
                         FirstName = p.FirstName,
                         LastName = p.LastName,
                         PositionID = p.PositionID,
                         PositionTitle = p.Position.Name,
                         DepartmentName = p.Position.Department.Name
                     }).ToListAsync();

                return pokeCatchers;
            }
        }
        public async Task<PokemonCatcherDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemonCatcher =
                    await
                    ctx
                    .PokemonCatchers
                    .Include(p=>p.Position)
              //      .Where(p => p.OwnerID == _userId)
                    .SingleOrDefaultAsync(p => p.EmployeeID == id);
                if (pokemonCatcher is null)
                {
                    return null;
                }
                return new PokemonCatcherDetail
                {
                    EmployeeID = pokemonCatcher.EmployeeID,
                    FirstName = pokemonCatcher.FirstName,
                    LastName = pokemonCatcher.LastName,
                    Position = new PositionListItem
                    {
                       PositionID=pokemonCatcher.PositionID,
                       Name=pokemonCatcher.Position.Name
                    },
                    CreationDate=pokemonCatcher.CreationDate,
                    ModificationDate=pokemonCatcher.ModificationDate
                };
            }
        }
        public async Task<bool> Post(PokemonCatcherCreate pokemonCatcher)
        {
            var entity = new PokemonCatcher
            {
                OwnerID = _userId,
                FirstName = pokemonCatcher.FirstName,
                LastName = pokemonCatcher.LastName,
                PositionID = pokemonCatcher.PositionID,
                ImageSource=pokemonCatcher.ImageSource,
                CreationDate = DateTime.Now,

            };
            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == entity.FirstName && a.LastName == entity.LastName);

                var position = await ctx.Positions.SingleOrDefaultAsync(d => d.PositionID == pokemonCatcher.PositionID);

                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == pokemonCatcher.DepartmentID);
                if (department is null)
                {
                    return false;
                }

                position.Department = department;

                entity.Position = position;

                entity.Position.DepartmentID = department.ID;

                var employeeConversion = new Employee
                {
                    OwnerID = _userId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PositionID = position.PositionID,
                    Position = position,
                    ImageSource=entity.ImageSource,
                    CreationDate = DateTime.Now
                };

                if (position.AvailablePositionCount > 0)
                {
                    ctx.Employees.Add(employeeConversion);
                    ctx.PokemonCatchers.Add(entity);
                    department.Employees.Add(entity);

                    //Reduces the avialible open positions for this speciffic position.
                    position.AvailablePositionCount--;

                    //removes the applicant from the applicant table
                    ctx.Applicants.Remove(applicant);

                    if (await ctx.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
                return false;

            }
        }
        public async Task<bool> Put(PokemonCatcherEdit pokemonCatcher, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPokemonCatcherData = await ctx.PokemonCatchers.FindAsync(id);
                if (oldPokemonCatcherData is null)
                {
                    return false;
                }
                oldPokemonCatcherData.FirstName = pokemonCatcher.FirstName;
                oldPokemonCatcherData.LastName = pokemonCatcher.LastName;
                pokemonCatcher.ModificationionDate = DateTime.Now;

                if (await ctx.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokeCatcher = await ctx.PokemonCatchers.FindAsync(id);
                if (pokeCatcher is null)
                {
                    return false;
                }
                var employee = await ctx.Employees.SingleOrDefaultAsync(e => e.FirstName == pokeCatcher.FirstName && e.LastName == pokeCatcher.LastName);
                if (employee is null)
                {
                    return false;
                }
                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == pokeCatcher.PositionID);
                if (position is null)
                {
                    return false;
                }
                ctx.Employees.Remove(employee);
                ctx.PokemonCatchers.Remove(pokeCatcher);
                position.AvailablePositionCount++;
                if (await ctx.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
