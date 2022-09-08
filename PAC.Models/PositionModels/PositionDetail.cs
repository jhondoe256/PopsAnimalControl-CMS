using PAC.Data.Departments;
using PAC.Models.DepartmentModels.Department_Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PositionModels
{
    public class PositionDetail
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }

        [Display(Name = "Avalilable Positions:")]
        public int AvailablePositionCount { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
