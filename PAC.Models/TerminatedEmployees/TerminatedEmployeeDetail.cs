using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.TerminatedEmployees
{
    public class TerminatedEmployeeDetail
    {
        public int EmployeeID { get; set; }
        
        [Display(Name ="Employee Name")]
        public string FullName { get; }
        public bool IsFired { get; set; }
        public DateTime DateOfTermination { get; set; }
        public int RehireableChances { get; set; }
        public bool IsRehaireable { get; set; }
        
        public int PositionID { get; set; }

        [Display(Name ="Position Title")]
        public string PositionTitle { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}
