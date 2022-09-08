using PAC.Data.Contracts.IApplicants;
using PAC.Data.Contracts.IEmployees;
using PAC.Data.Contracts.IEmployees.IHuman_R.IHired_Emp;
using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.HumanResource_s.HiredEmployee_s
{
    public class HiredEmployee : IHireable,IEmployee
    {
        [Key]
        public int HireID { get; set; }
        public Guid OwnerID { get; set; }
        public DateTime EmployeeDateOfHire { get; set; }
        public int HireableEmployeeCount { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        public int PositionID { get; set; }
        public Position Position { get; set; }
        public bool isFired { get; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentID { get; set; }
        public Department Department { get; set; }

        public string ImageSource { get; set; }
    }
}
