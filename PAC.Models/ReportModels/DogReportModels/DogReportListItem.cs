using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ReportModels.DogReportModels
{
   public class DogReportListItem
    {
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
