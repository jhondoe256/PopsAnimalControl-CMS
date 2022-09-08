using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IEmployees
{
    public interface IEmployeeReportInfo
    {
        Guid OwnerID { get; set; }
        int EmployeeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
