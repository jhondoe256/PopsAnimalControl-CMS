using PAC.Data.Employees;
using PAC.Data.Employees.HouesKeepers;
using PAC.Models.HouseKeeperModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.HouseKeepingServices
{
    public class HouseKeepingService
    {
        private readonly Guid _userId;
        public HouseKeepingService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<HouseKeeperListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .HouseKeepers
                    .Include(h=>h.Position)
                    .Where(h => h.OwnerID == _userId)
                    .Select(h => new HouseKeeperListItem
                    {
                        EmployeeID=h.EmployeeID,
                        FirstName=h.FirstName,
                        LastName=h.LastName,
                        PositionID=h.PositionID,
                        PositionTitle=h.Position.Name
                    }).ToListAsync();
                return query;
            }
        }
        public async Task<HouseKeeperDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var hKeeper = await
                    ctx
                    .HouseKeepers
                    .Include(h=>h.Position)
                    .Where(h => h.OwnerID == _userId)
                    .SingleOrDefaultAsync(h => h.EmployeeID == id);

                return new HouseKeeperDetail
                {
                    EmployeeID=hKeeper.EmployeeID,
                    FirstName=hKeeper.FirstName,
                    LastName=hKeeper.LastName,
                    PositionID=hKeeper.PositionID,
                    Position=hKeeper.Position,
                    CreationDate=hKeeper.CreationDate,
                    ModificationionDate=hKeeper.ModificationDate
                };
            }
        }
        public async Task<bool> Post(HouseKeeperCreate houseKeeper)
        {
            var entity = new HouseKeeper
            {
                OwnerID = _userId,
                FirstName = houseKeeper.FirstName,
                LastName = houseKeeper.LastName,
                PositionID = houseKeeper.PositionID,
                ImageSource=houseKeeper.ImageSource,
                CreationDate = DateTime.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == houseKeeper.FirstName && a.LastName == houseKeeper.LastName);
                if (applicant is null)
                {
                    return false;
                }

                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == houseKeeper.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == houseKeeper.DepartmentID);
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
                    ctx.HouseKeepers.Add(entity);
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
        public async Task<bool> Put(HouseKeeperEdit houseKeeper, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.HouseKeepers.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = houseKeeper.FirstName;
                oldData.LastName = houseKeeper.LastName;
                oldData.ModificationDate = DateTime.Now;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var hKeeper = await ctx.HouseKeepers.FindAsync(id);
                if (hKeeper is null)
                {
                    return false;
                }
                ctx.HouseKeepers.Remove(hKeeper);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
