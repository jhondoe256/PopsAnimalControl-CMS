using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.EmployeeModels
{
    public class EmployeeListItem
    {
        public int EmployeeID { get; set; }
        public string FullName { get; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }

    }
}
