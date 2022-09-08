using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.VetTechModels
{
    public class VetTechDetail
    {
        public int EmployeeID { get; set; }
        public int PositionID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isFired { get; }
        public Position Position { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}
