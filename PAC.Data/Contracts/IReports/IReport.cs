using PAC.Data.Contracts.IEmployees;
using PAC.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IReports
{
    public interface IReport :IEmployeeReportInfo
    {
        int ReportID { get; set; }
    }
}
