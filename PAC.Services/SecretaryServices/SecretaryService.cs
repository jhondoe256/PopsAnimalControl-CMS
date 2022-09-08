using PAC.Data.Employees;
using PAC.Data.Secretaries;
using PAC.Models.SecretaryModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.SecretaryServices
{
    public class SecretaryService
    {
        private Guid _userId;
        public SecretaryService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<SecretaryListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Secretaries
                    .Where(s => s.OwnerID == _userId)
                    .Select( s => new SecretaryListItem
                    {
                        EmployeeID=s.EmployeeID,
                        FirstName=s.FirstName,
                        LastName=s.LastName,
                        PositionID=s.PositionID,
                        PositionTitle= ctx.Positions.Find(s.PositionID).Name
                    }).ToListAsync();

                return query;
            }
        }
        public async Task<SecretaryDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var secretary =
                    await
                    ctx
                    .Secretaries
                    .Include(s=>s.Position)
                    .Where(s => s.OwnerID == _userId)
                    .SingleOrDefaultAsync(s => s.EmployeeID == id);

                return new SecretaryDetail
                {
                    EmployeeID=secretary.EmployeeID,
                    FirstName=secretary.FirstName,
                    LastName=secretary.LastName,
                    PositionID=secretary.PositionID,
                    PositionTitle=secretary.Position.Name,
                    CreationDate=secretary.CreationDate,
                    ModificationionDate=DateTime.Now
                };
            }
        }
        public async Task<bool> Post(SecretaryCreate secretary)
        {
            var entity = new Secretary
            {
                OwnerID = _userId,
                FirstName = secretary.FirstName,
                LastName = secretary.LastName,
                PositionID = secretary.PositionID,
                ImageSource=secretary.ImageSource,
                CreationDate = DateTime.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == secretary.FirstName && a.LastName == secretary.LastName);
                if (applicant is null)
                {
                    return false;
                }

                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == secretary.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == secretary.DepartmentID);
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
                    ctx.Secretaries.Add(entity);
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
        public async Task<bool> Put(SecretaryEdit secretary,int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.Secretaries.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = secretary.FirstName;
                oldData.LastName = secretary.LastName;
                oldData.PositionID = secretary.PositionID;
                oldData.Position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == secretary.PositionID);
                oldData.ModificationDate = DateTime.Now;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var secretary = await ctx.Secretaries.FindAsync(id);
                if (secretary is null)
                {
                    return false;
                }
                ctx.Secretaries.Remove(secretary);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
