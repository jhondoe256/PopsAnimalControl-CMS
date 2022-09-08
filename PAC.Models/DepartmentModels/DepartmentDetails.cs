using PAC.Data.Contracts.IEmployees;
using PAC.Data.Employees;
using PAC.Data.Employees.Positions;
using PAC.Models.DepartmentModels.Department_Positions;
using PAC.Models.DepartmentModels.DepartmentDetailsEmployeeListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.DepartmentModels
{
    public class DepartmentDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public virtual List<DepartmentDetailsEmployeeListItem> Employees { get; set; } = new List<DepartmentDetailsEmployeeListItem>();
        public List<DepartmentPositionListItem> Department_Positions { get; set; } = new List<DepartmentPositionListItem>();
    }
}
