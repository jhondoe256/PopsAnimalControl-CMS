using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IEmployees.IHuman_R.IReferences
{
    public interface IReference
    {
        //int ReferenceID { get; set; }
        string CompanyName { get; set; }
        string ReferenceFirstName { get; set; }
        string ReferenceLastName { get; set; }
        string Address { get; set; }
        DateTime? DateStarted { get; set; }
        DateTime? DateEnded { get; set; }
        bool MayWeContactThisEmployer { get; set; }

    }
}
