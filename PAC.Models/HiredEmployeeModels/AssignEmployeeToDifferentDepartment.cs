using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.HiredEmployeeModels
{
    public class AssignEmployeeToDifferentDepartment
    {
        //GETS THE SPECIFIC EMPLOYEE NEEDED
        public int EmployeeID { get; set; }
        
        //THE VALUE OF THE DEPARTMENT EMPLOYEE IS BEING CHANGED TO 
        public int DepartmentID { get; set; }

        //THE VALUE OF THE POSITION THAT THE EMPLOYEE IS BEING CHANGED TO 
        public int PositionID { get; set; }
    }
}
