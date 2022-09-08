using PAC.Data.DogCatchers;
using PAC.Data.Employees;
using PAC.Data.HumanResource_s.HiredEmployee_s;
using PAC.Models.DogCatcherModels;
using PAC.Models.PositionModels;
using PAC.Services.Contracts.IDogCatcher_Repository;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.DogCatcherServices
{
    public class DogCatcherService
    {
        private readonly Guid _userId;
        private ApplicationDbContext _context = new ApplicationDbContext();

        public DogCatcherService(Guid userID)
        {
            _userId = userID;

        }
        public async Task<bool> Delete(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var dogCatcher = await ctx.DogCatchers.FindAsync(id);
                if (dogCatcher is null)
                {
                    return false;
                }
                var employee = await ctx.Employees.SingleOrDefaultAsync(e => e.FirstName == dogCatcher.FirstName && e.LastName == dogCatcher.LastName);
                if (employee is null)
                {
                    return false;
                }
                var position = await ctx.Positions.SingleOrDefaultAsync(p => p.PositionID == dogCatcher.PositionID);
                if (position is null)
                {
                    return false;
                }
                ctx.Employees.Remove(employee);
                ctx.DogCatchers.Remove(dogCatcher);
                position.AvailablePositionCount++;
            }

            return await Save();
        }
        public async Task<List<DogCatcherListItem>> Get()
        {
            var dogCatchers = await _context.DogCatchers.Include(d => d.Position)
            .Select(c => new DogCatcherListItem
            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PositionID = c.PositionID,
                CreationDate = c.CreationDate,
                ModificationionDate = c.ModificationDate,
                PositionTitle = c.Position.Name
            }).ToListAsync();

            return dogCatchers;
        }
        public async Task<DogCatcherDetail> Get(int id)
        {
            var dogCatcher = await _context.DogCatchers
                .Include(d => d.Position)
                .Include(d => d.Position.Department)
                .SingleOrDefaultAsync(d => d.EmployeeID == id);
            if (dogCatcher != null)
            {
                var fullName = $"{dogCatcher.FirstName} {dogCatcher.LastName}";
                return new DogCatcherDetail
                {
                    EmployeeID = dogCatcher.EmployeeID,
                    FirstName = dogCatcher.FirstName,
                    LastName = dogCatcher.LastName,
                    FullName = fullName,
                    Position = new PositionListItem
                    {
                        PositionID = dogCatcher.PositionID,
                        Name = _context.DogCatchers.Find(dogCatcher.PositionID).Position.Name

                    },
                    CreationDate = dogCatcher.CreationDate,
                    ModificationDate = dogCatcher.ModificationDate
                };
            }
            return null;
        }
        public async Task<bool> Post(DogCatcherCreate model)
        {
            var applicant = _context.Applicants.SingleOrDefault(a => a.FirstName == model.FirstName && a.LastName == model.LastName);
            if (applicant is null)
            {
                return false;
            }
          
            var entity = new DogCatcher
            {
                OwnerID = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PositionID = model.PositionID,
                CreationDate = DateTime.Now
            };

            var position = await _context.Positions.SingleOrDefaultAsync(p => p.PositionID == model.PositionID);
            if (position is null)
            {
                return false;
            }

            var department = await _context.Departments.SingleOrDefaultAsync(d => d.ID == model.DepartmentID);
            if (department is null)
            {
                return false;
            }

            position.Department = department;

            entity.Position = position;
            entity.Position.DepartmentID = department.ID;

            //have to make the entity an employee for the department.Employees to see the employee list
            var EmployeeConversion = new Employee
            {
                OwnerID = _userId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Position = position,
                CreationDate = DateTime.Now
            };


            if (position.AvailablePositionCount > 0)
            {
                _context.Employees.Add(EmployeeConversion);
                _context.DogCatchers.Add(entity);
                department.Employees.Add(entity);

                //Reduces the avialible open positions for this speciffic position.
                position.AvailablePositionCount--;

                //removes the applicant from the applicant table
                _context.Applicants.Remove(applicant);

                return await Save();
            }

            return false;
        }
        public async Task<bool> Put(DogCatcher entity)
        {
            var oldDogCatcherData = await _context.DogCatchers.SingleOrDefaultAsync(d => d.EmployeeID == entity.EmployeeID);
            if (oldDogCatcherData != null)
            {
                oldDogCatcherData.FirstName = entity.FirstName;
                oldDogCatcherData.LastName = entity.LastName;
                return await Save();
            }
            return false;
        }
        public async Task<bool> Put(DogCatcherEdit dogCatcher, int id)
        {
            var oldDCData = await _context.DogCatchers.SingleOrDefaultAsync(d => d.EmployeeID == id);
            if (oldDCData != null)
            {
                oldDCData.FirstName = dogCatcher.FirstName;
                oldDCData.LastName = dogCatcher.LastName;
                oldDCData.ModificationDate = DateTime.UtcNow;
                return await Save();
            }
            return false;
        }
        public async Task<bool> Save()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
    }
}

