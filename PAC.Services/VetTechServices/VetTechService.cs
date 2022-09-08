using PAC.Data.Contracts.VetTechs;
using PAC.Data.Employees;
using PAC.Models.VetTechModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.VetTechServices
{
    public class VetTechService
    {
        private readonly Guid _userId;
        public VetTechService(Guid userId)
        {
            _userId = userId;
        }
        public async Task<IEnumerable<VetTechListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .VetTechs
                    .Include(v=>v.Position)
                    .Where(v => v.OwnerID == _userId)
                    .Select(v => new VetTechListItem
                    {
                        EmployeeID=v.EmployeeID,
                        FirstName=v.FirstName,
                        LastName=v.LastName,
                        PositionID=v.PositionID,
                        PositionTitle=v.Position.Name
                    }).ToListAsync();

                return query;
            }
        }
        public async Task<VetTechDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var vt =
                    await
                    ctx
                    .VetTechs
                    .Where(v => v.OwnerID == _userId)
                    .SingleOrDefaultAsync(v => v.EmployeeID == id);
                if (vt is null)
                {
                    return null;
                }
                return new VetTechDetail
                {
                    EmployeeID=vt.EmployeeID,
                    FirstName=vt.FirstName,
                    LastName=vt.LastName,
                    PositionID=vt.PositionID,
                    Position=vt.Position,
                    CreationDate=vt.CreationDate,
                    ModificationionDate=vt.ModificationDate
                };
            }
        }
        public async Task<bool> Post(VetTechCreate vetTech)
        {
            var entity = new VetTech
            {
                OwnerID = _userId,
                FirstName = vetTech.FirstName,
                LastName = vetTech.LastName,
                PositionID = vetTech.PositionID,
                ImageSource=vetTech.ImageSource,
                CreationDate = DateTime.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                var applicant = await ctx.Applicants.SingleOrDefaultAsync(a => a.FirstName == vetTech.FirstName && a.LastName == vetTech.LastName);
                if (applicant is null)
                {
                    return false;
                }

                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == vetTech.PositionID);
                if (position is null)
                {
                    return false;
                }

                var department = await ctx.Departments.SingleOrDefaultAsync(d => d.ID == vetTech.DepartmentID);
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
                    ctx.VetTechs.Add(entity);
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
        public async Task<bool> Put(VetTechEdit vetTech, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.VetTechs.FindAsync(id);
                if (oldData is null)
                {
                    return false;
                }
                oldData.FirstName = vetTech.FirstName;
                oldData.LastName = vetTech.LastName;
                oldData.ModificationDate = DateTime.Now;

                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var vt = await ctx.VetTechs.FindAsync(id);
                if (vt is null)
                {
                    return false;
                }
                ctx.VetTechs.Remove(vt);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
