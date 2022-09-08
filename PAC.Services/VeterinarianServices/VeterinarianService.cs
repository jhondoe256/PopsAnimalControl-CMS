using PAC.Data.Employees;
using PAC.Data.Veterinarians;
using PAC.Models.VeterinarianModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.VeterinarianServices
{
    public class VeterinarianService
    {
        private readonly Guid _userId;
        public VeterinarianService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<VeterinarianListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Veterinarians
                    .Include(v => v.Position)
                    .Where(v => v.OwnerID == _userId)
                    .Select(v => new VeterinarianListItem
                    {
                        EmployeeID = v.EmployeeID,
                        PositionID = v.PositionID,
                        PositionTitle = v.Position.Name
                    }).ToListAsync();
                return query;
            }
        }
        public async Task<VeterinarianDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var vet = await
                    ctx
                    .Veterinarians
                    .Where(v => v.OwnerID == _userId)
                    .SingleOrDefaultAsync(v => v.EmployeeID == id);

                if (vet is null)
                {
                    return null;
                }

                return new VeterinarianDetail
                {
                    EmployeeID = vet.EmployeeID,
                    FirstName = vet.FirstName,
                    LastName = vet.LastName,
                    PositionID = vet.PositionID,
                    Position = vet.Position,
                    CreationDate = vet.CreationDate,
                    ModificationionDate = vet.ModificationDate
                };
            }
        }
        public async Task<bool> Post(VeterinarianCreate veterinarian)
        {
            var entity = new Veterinarian
            {
                OwnerID = _userId,
                FirstName = veterinarian.FirstName,
                LastName = veterinarian.LastName,
                PositionID = veterinarian.PositionID,
                ImageSource=veterinarian.ImageSource,
                CreationDate = DateTime.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == veterinarian.FirstName && a.LastName == veterinarian.LastName);
                if (applicant is null)
                {
                    return false;
                }

                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == veterinarian.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == veterinarian.DepartmentID);
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
                    EmployeeID = entity.EmployeeID,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    PositionID = position.PositionID,
                    ImageSource=entity.ImageSource,
                    CreationDate = DateTime.Now
                };

                if (position.AvailablePositionCount > 0)
                {
                    ctx.Employees.Add(employeeConversion);
                    ctx.Veterinarians.Add(entity);
                    department.Employees.Add(entity);

                    //Reduces the avialible open positions for this speciffic position.
                    position.AvailablePositionCount--;

                    //removes the applicant from the applicant table
                    ctx.Applicants.Remove(applicant);

                    return await ctx.SaveChangesAsync() > 0;
                }

                return false;

            }

        }
        public async Task<bool> Put(VeterinarianEdit veterinarian, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.Managers.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = veterinarian.FirstName;
                oldData.LastName = veterinarian.LastName;
                oldData.ModificationDate = DateTime.Now;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var vet = await ctx.Veterinarians.FindAsync(id);
                if (vet is null)
                {
                    return false;
                }
                ctx.Veterinarians.Remove(vet);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
