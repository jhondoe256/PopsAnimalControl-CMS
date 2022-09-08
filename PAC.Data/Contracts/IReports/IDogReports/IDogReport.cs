using PAC.Data.Contracts.IAnimals.IDogs;
using PAC.Data.Contracts.IReports.IEventDescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IReports.IDogReports
{
    public interface IDogReport:IReport,IDog,IEventDescription
    {
    }
}
