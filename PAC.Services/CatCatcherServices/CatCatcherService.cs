using PAC.Data.CatCatchers;
using PAC.Data.Employees;
using PAC.Data.Employees.Positions;
using PAC.Models.CatcherModels;
using PAC.Models.PositionModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.CatCatcherServices
{
    public class CatCatcherService
    {
        private readonly Guid _userId;
        public CatCatcherService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var catCatcher = await ctx.CatCatchers.FindAsync(id);
                if (catCatcher is null)
                {
                    return false;
                }
                var employee = await ctx.Employees.SingleOrDefaultAsync(e => e.FirstName == catCatcher.FirstName && e.LastName == catCatcher.LastName);
                if (employee is null)
                {
                    return false;
                }
                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == catCatcher.PositionID);
                if (position is null)
                {
                    return false;
                }
                ctx.Employees.Remove(employee);
                ctx.CatCatchers.Remove(catCatcher);
                position.AvailablePositionCount++;
                if (await ctx.SaveChangesAsync()>0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<IEnumerable<CatCatcherListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .CatCatchers
                    .Include(c => c.Position)
           //         .Where(c => c.OwnerID == _userId)
                    .Select(c => new CatCatcherListItem
                    {
                        EmployeeID = c.EmployeeID,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        PositionID = c.PositionID,
                        PositionName = c.Position.Name,
                        DepartmentName = c.Position.Department.Name

                    }).ToListAsync();
                return query;
            }
        }

        public async Task<CatCatcherDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var catCatcher = await
                    ctx
                    .CatCatchers
                    .Include(c => c.Position)
          //          .Where(c => c.OwnerID == _userId)
                    .SingleOrDefaultAsync(c => c.EmployeeID == id);
                if (catCatcher is null)
                {
                    return null;
                }
                var fullName = $"{catCatcher.FirstName} {catCatcher.LastName}";
                return new CatCatcherDetail
                {
                    EmployeeID = catCatcher.EmployeeID,
                    FirstName=catCatcher.FirstName,
                    LastName=catCatcher.LastName,
                    FullName=fullName,
                    Position = new PositionListItem 
                    {
                       PositionID=catCatcher.PositionID,
                       Name=catCatcher.Position.Name

                    },
                    CreationDate = catCatcher.CreationDate,
                    ModificationDate = catCatcher.ModificationDate
                };
            }
        }

        public async Task<bool> Post(CatCatcherCreate catCatcher)
        {
            var entity = new CatCatcher
            {
                OwnerID = _userId,
                FirstName = catCatcher.FirstName,
                LastName = catCatcher.LastName,
                PositionID = catCatcher.PositionID,
                CreationDate = DateTime.Now,
                ImageSource=catCatcher.ImageSource
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == entity.FirstName && a.LastName == entity.LastName);

                var position = await ctx.Positions.SingleOrDefaultAsync(d => d.PositionID == catCatcher.PositionID);

                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == catCatcher.DepartmentID);
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
                    ctx.CatCatchers.Add(entity);
                    department.Employees.Add(entity);

                    //Reduces the avialible open positions for this speciffic position.
                    position.AvailablePositionCount--;

                    //removes the applicant from the applicant table
                    ctx.Applicants.Remove(applicant);

                    if (await ctx.SaveChangesAsync()>0)
                    {
                        return true;
                    }
                }
                return false;

            }
        }

        public async Task<bool> Put(CatCatcherEdit catCatcher, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var catCatcherData = await ctx.CatCatchers.FindAsync(id);
                if (catCatcherData is null)
                {
                    return false;
                }
                catCatcherData.FirstName = catCatcher.FirstName;
                catCatcherData.LastName = catCatcher.LastName;
             //   catCatcherData.PositionID = catCatcher.PositionID;
             //   catCatcherData.Position = await ctx.Positions.SingleOrDefaultAsync(c => c.PositionID == id);
                catCatcher.ModificationDate = DateTime.Now;

                if (await ctx.SaveChangesAsync()>0)
                {
                    return true;
                }
                return false;
            }
        }

     
    }
}
