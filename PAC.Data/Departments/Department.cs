using PAC.Data.Contracts.IDepartments;
using PAC.Data.Contracts.IEmployees;
using PAC.Data.Employees;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Departments
{
    public class Department : IDepartment
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<IEmployee> Employees { get; set; } = new List<IEmployee>();
        public virtual List<Position> Department_Positions { get; set; } = new List<Position>();
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public Guid OwnerID { get; set; }
    }
}
