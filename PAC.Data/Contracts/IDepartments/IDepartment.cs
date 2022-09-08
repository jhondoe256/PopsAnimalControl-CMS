using PAC.Data.Contracts.IEmployees;
using PAC.Data.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IDepartments
{
    public interface IDepartment
    {
        Guid OwnerID { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        DateTime CreationDate { get; set; }
        DateTime? ModificationionDate { get; set; }
        List<IEmployee> Employees { get; set; }
    }
}
