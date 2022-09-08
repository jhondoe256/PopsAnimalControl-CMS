using PAC.Data.Contracts.IAnimals.ICats;
using PAC.Data.Contracts.IReports.IEventDescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IReports.ICatReports
{
    public interface ICatReport:IReport,ICat,IEventDescription
    {
    }
}
