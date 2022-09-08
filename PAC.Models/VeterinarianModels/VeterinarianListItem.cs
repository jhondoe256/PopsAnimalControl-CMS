using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.VeterinarianModels
{
    public class VeterinarianListItem
    {
        public int EmployeeID { get; set; }
        public string FullName { get; }
        public int PositionID { get; set; }

        [Display(Name ="Position Title")]
        public string PositionTitle { get; set; }

    }
}
