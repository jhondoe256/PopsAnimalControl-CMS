using PAC.Data.Contracts.IReports;
using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Reports
{
    public class Report : IReport
    {
        public int ReportID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public int EmployeeID { get; set; }


        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
