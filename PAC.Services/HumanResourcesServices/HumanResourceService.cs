using PAC.Data.Employees;
using PAC.Data.HumanResource_s;
using PAC.Models.HumanResourceModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.HumanResourcesServices
{
    public class HumanResourceService
    {
        //  private readonly Guid _userId;
        //public HumanResourceService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public HumanResourceService()
        {

        }
        public async Task<IEnumerable<HumanResourceListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx.
                    HumanResources
                   // .Where(h => h.OwnerID == _userId)
                    .Select(h => new HumanResourceListItem
                    {
                        EmployeeID = h.EmployeeID,
                        FirstName = h.FirstName,
                        LastName = h.LastName,
                        PositionID = h.PositionID,
                        PositionTitle = ctx.Positions.SingleOrDefault(p => p.PositionID == h.PositionID).Name
                    }).ToListAsync();

                return query;
            }
        }
        public async Task<HumanResourceDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var hRsEmp = await ctx.HumanResources.Include(h => h.Position).SingleOrDefaultAsync(h => h.EmployeeID == id);
                if (hRsEmp is null)
                {
                    return null;
                }
                return new HumanResourceDetail
                {
                    EmployeeID = hRsEmp.EmployeeID,
                    FirstName = hRsEmp.FirstName,
                    Last = hRsEmp.LastName,
                    PositionID = hRsEmp.PositionID,
                    Position = hRsEmp.Position,
                    CreationDate = hRsEmp.CreationDate,
                    ModificationionDate = DateTime.Now
                };
            }
        }
        public async Task<bool> Post(HumanResourceCreate humanResource)
        {
            var entity = new HumanResources
            {
             //   OwnerID = _userId,
                FirstName = humanResource.FirstName,
                LastName = humanResource.LastName,
                PositionID = humanResource.PositionID,
                CreationDate = DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == humanResource.FirstName && a.LastName == humanResource.LastName);
                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == humanResource.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == humanResource.DepartmentID);
                if (department is null)
                {
                    return false;
                }

                position.Department = department;
                entity.Position = position;

                entity.Position.DepartmentID = department.ID;

                var employeeConversion = new Employee()
                {
                //    OwnerID = _userId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Position = position,
                    PositionID = position.PositionID,
                    CreationDate = DateTime.Now,
                };

                if (position.AvailablePositionCount > 0)
                {
                    ctx.Employees.Add(employeeConversion);
                    ctx.HumanResources.Add(entity);
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
        public async Task<bool> Put(HumanResourceEdit humanResource, int id) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.HumanResources.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = humanResource.FirstName;
                oldData.LastName = humanResource.LastName;
                oldData.ModificationDate = DateTime.Now;

                return await ctx.SaveChangesAsync()>0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var hRsEmployee = await ctx.HumanResources.FindAsync(id);
                if (hRsEmployee is null)
                {
                    return false;
                }
                ctx.HumanResources.Remove(hRsEmployee);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

    }
}
