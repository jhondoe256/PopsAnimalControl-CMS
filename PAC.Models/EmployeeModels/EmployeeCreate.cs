using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.EmployeeModels
{
    public class EmployeeCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageSource { get; set; }
    }
}
