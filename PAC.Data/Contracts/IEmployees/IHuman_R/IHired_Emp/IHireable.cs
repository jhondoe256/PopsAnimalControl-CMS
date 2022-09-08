using PAC.Data.Contracts.IApplicants;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IEmployees.IHuman_R.IHired_Emp
{
    public interface IHireable
    {
        int HireID { get; set; }
     
        int HireableEmployeeCount { get; set; }
        DateTime EmployeeDateOfHire { get; set; }
     

    }
}
