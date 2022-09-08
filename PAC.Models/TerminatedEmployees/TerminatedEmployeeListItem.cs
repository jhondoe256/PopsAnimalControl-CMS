using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.TerminatedEmployees
{
    public class TerminatedEmployeeListItem
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfTermination { get; set; }
        public int PositionID { get; set; }
       
    }
}
