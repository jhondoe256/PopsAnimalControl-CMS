using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.HumanResourceModels
{
    public class HumanResourceDetail
    {
        public int EmployeeID { get; set; }

        [Display(Name = "Employee First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string Last { get; set; }

        public bool isFired { get; }

        
        public int PositionID { get; set; }
        public Position Position { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}
