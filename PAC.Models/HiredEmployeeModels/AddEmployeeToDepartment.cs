using PAC.Data.Contracts.IEmployees;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.HiredEmployeeModels
{
    public class AddEmployeeToDepartment
    {
        public Guid OwnerID { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime EmployeeDateOfHire { get; set; }
       
    }
}
