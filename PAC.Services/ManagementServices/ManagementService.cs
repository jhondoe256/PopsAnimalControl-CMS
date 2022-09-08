using PAC.Data.Employees;
using PAC.Data.Managers;
using PAC.Models.ManagementModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ManagementServices
{
    public class ManagementService
    {
        private readonly Guid _userId;
        public ManagementService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<ManagementListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Managers
                    .Include(m=>m.Position)
                  //  .Where(m => m.OwnerID == _userId)
                    .Select(m => new ManagementListItem
                    {
                        EmployeeID=m.EmployeeID,
                        FirstName=m.FirstName,
                        LastName=m.LastName,
                        PositionID=m.PositionID,
                        PositionTitle=m.Position.Name
                    }).ToListAsync();

                return query;
            }
        }
        public async Task<ManagementDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager =
                    await
                    ctx
                    .Managers.Include(m=>m.Position).SingleOrDefaultAsync(m => m.EmployeeID == id);

                if (manager is null)
                {
                    return null;
                }

                return new ManagementDetail
                {
                    EmployeeID=manager.EmployeeID,
                    FirstName=manager.FirstName,
                    LastName=manager.LastName,
                    PositionID=manager.PositionID,
                    PositionTitle=manager.Position.Name,
                    CreationDate=manager.CreationDate,
                    ModificationionDate=DateTime.Now
                };
            }
        }
        public async Task<bool> Post(ManagementCreate manager)
        {
            var entity = new Manager
            {
                OwnerID = _userId,
                FirstName=manager.FirstName,
                LastName=manager.LastName,
                PositionID=manager.PositionID,
                ImageSource=manager.ImageSource,
                CreationDate=DateTime.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == manager.FirstName && a.LastName == manager.LastName);
                if (applicant is null)
                {
                    return false;
                }

                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == manager.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == manager.DepartmetID);
                if (department is null)
                {
                    return false;
                }

                position.Department = department;
                entity.Position = position;
                entity.Position.DepartmentID = department.ID;

                var employeeConversion = new Employee
                {
                    OwnerID=_userId, 
                    EmployeeID=entity.EmployeeID,
                    FirstName=entity.FirstName,
                    LastName=entity.LastName,
                    PositionID=position.PositionID,
                    ImageSource=entity.ImageSource,
                    CreationDate=DateTime.Now
                };

                if (position.AvailablePositionCount > 0)
                {
                    ctx.Employees.Add(employeeConversion);
                    ctx.Managers.Add(entity);
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
        public async Task<bool> Put(ManagementEdit management, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.Managers.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = management.FirstName;
                oldData.LastName = management.LastName;
                oldData.ModificationDate = DateTime.Now;
                
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var manager = await ctx.Managers.FindAsync(id);
                if (manager is null)
                {
                    return false;
                }
                ctx.Managers.Remove(manager);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
