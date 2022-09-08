using PAC.Data.Employees;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PAC.Services.EmployeeServices
{
    public class EmployeeService
    {
        private readonly Guid _userID;
        public EmployeeService(Guid userID)
        {
            _userID = userID;
        }
        //NEEDS REFACTORING!!!
        public bool DeleteAllEmployeesViaDepartment(int departmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Employee> employees = ctx.Employees.Include(e=>e.Position).Where(d => d.Position.DepartmentID == departmentID).ToList();
                
                foreach (var item in employees)
                {
                    item.Position.Department = ctx.Departments.Find(item.Position.DepartmentID);
                    if (item.Position.Department.ID==departmentID)
                    {
                        item.Position.Department.Employees.Remove(item);
                    }
                }
                if (employees is null)
                {
                    return false;
                }
                foreach (var item in employees)
                {
                    ctx.Employees.Remove(item);
                }
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
