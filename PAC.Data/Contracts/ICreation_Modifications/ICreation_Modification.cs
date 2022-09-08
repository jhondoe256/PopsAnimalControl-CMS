using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.ICreation_Modifications
{
    public interface ICreation_Modification
    {
        DateTime CreationDate { get; set; }
        DateTime? ModificationDate { get; set; }
    }
}
