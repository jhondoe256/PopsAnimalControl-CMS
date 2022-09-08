using PAC.Data.Contracts.ICreation_Modifications;
using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IEmployees
{
    public interface IEmployee : ICreation_Modification
    {
        Guid OwnerID { get; set; }
        int EmployeeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        int PositionID { get; set; }
        Position Position{ get; set; }
        bool isFired { get; }
        string ImageSource { get; set; }
    }
}
