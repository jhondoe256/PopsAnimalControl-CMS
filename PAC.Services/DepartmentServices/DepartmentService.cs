using PAC.Data.CatCatchers;
using PAC.Data.Departments;
using PAC.Data.DogCatchers;
using PAC.Data.Employees;
using PAC.Data.PokemonCatchers;
using PAC.Models.DepartmentModels;
using PAC.Models.DepartmentModels.Department_Positions;
using PAC.Models.DepartmentModels.DepartmentDetailsEmployeeListModel;
using PAC.Services.Utilities;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.DepartmentServices
{
    //Management/Admin access
    public class DepartmentService
    {
        private Guid _userId;
        public DepartmentService(Guid userID)
        {
            _userId = userID;
        }
        //public DepartmentService(string email)
        //{
        //    _userId = UtilityMethods.GetGuid(email);
        //}
        public DepartmentService()
        {

        }

        public async Task<bool> CreateDepartmentAsync(DepartmentCreate department)
        {
            var entity = new Department
            {
                OwnerID = _userId,
                Name=department.Name,
                CreationDate=DateTime.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<IEnumerable<DepartmentListItem>> GetDepartmentsAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Departments
                  //  .Where(d => d.OwnerID == _userId)
                    .Select(d => new DepartmentListItem
                    {
                        ID=d.ID,
                        Name=d.Name
                    });

                return await query.ToListAsync();
            }
        }
        public async Task<DepartmentDetails> GetDepartmentDetailsAsync(int departmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var department =
                    await
                    ctx
                    .Departments
               //     .Where(d => d.OwnerID == _userId)
                    .SingleOrDefaultAsync(d => d.ID == departmentID);

                if (department is null)
                {
                    return null;
                }
                else
                {
                    return new DepartmentDetails
                    {
                        ID = department.ID,
                        Name = department.Name,
                        Department_Positions = department.Department_Positions
                        .Select(d => new DepartmentPositionListItem { Name = d.Name }).ToList(),
                        Employees = ctx.Employees.Where(d=>d.Position.DepartmentID==department.ID)
                        .Select(e=>new DepartmentDetailsEmployeeListItem {FirstName=e.FirstName,LastName=e.LastName }).ToList(),
                        CreationDate = department.CreationDate,
                        ModificationionDate = (department.ModificationionDate==null)?null: department.ModificationionDate
                    };
                }
            }
        }
        public async Task<bool> UpdateDepartmentAsync(DepartmentEdit department, int departmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var departmentObj =await ctx.Departments.FindAsync(departmentID);
                if (departmentObj is null)
                {
                    return false;
                }
                departmentObj.Name = department.Name;
                departmentObj.ModificationionDate = DateTime.Now;

                return await ctx.SaveChangesAsync() > 0; 
            }
        }
        public async Task<bool> DeleteDepartmentAsync(int departmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var department = await ctx.Departments.FindAsync(departmentID);
                if (department is null)
                {
                    return false;
                }
                ctx.Departments.Remove(department);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> RemoveAllEmployeesFromDepartment(int departmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var department = await ctx.Departments.FindAsync(departmentID);
                if (department is null)
                {
                    return false;
                }
                else
                {
                    var employees = ctx.Employees.Where(d => d.Position.DepartmentID == department.ID).ToList();
                    foreach (var e in employees)
                    {
                        var emp = ctx.Employees.SingleOrDefault(em => em.EmployeeID == e.EmployeeID);
                        if (emp is null)
                        {
                            return false;
                        }

                        ctx.Employees.Remove(emp);
                        department.Employees.Remove(e);
                    }
                    await ctx.SaveChangesAsync();
                    return true;
                }

            }
        }
    }
}
