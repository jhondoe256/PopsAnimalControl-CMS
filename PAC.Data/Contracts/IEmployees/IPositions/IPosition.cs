using PAC.Data.Contracts.ICreation_Modifications;
using PAC.Data.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IEmployees.IPositions
{
    public interface IPosition : ICreation_Modification
    {
        Guid OwnerID {get;set;}
        int PositionID { get; set; }
        string Name { get; set; }
        int AvailablePositionCount { get; set; }
        int DepartmentID { get; set; }
        Department Department { get; set; }
    }
}
