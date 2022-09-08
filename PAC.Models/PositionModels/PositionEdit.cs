using PAC.Data.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PositionModels
{
    public class PositionEdit
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int AvailablePositionCount{get;set;}
        public DateTime ModificationDate { get; set; }
    }
}
