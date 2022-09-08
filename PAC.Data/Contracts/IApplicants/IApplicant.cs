using PAC.Data.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IApplicants
{
    //This can/will be expanded upon....
    public interface IApplicant
    {
        Guid OwnerID { get; set; }
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string SocialSecurityNumber { get; set; }
        string FullName { get; }
        int DepartmentID { get; set; }
        Department Department { get; set; }
    }
}
