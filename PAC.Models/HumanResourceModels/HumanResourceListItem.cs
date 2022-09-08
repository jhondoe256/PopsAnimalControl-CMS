using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.HumanResourceModels
{
    public class HumanResourceListItem
    {
        public int EmployeeID { get; set; }

        [Display(Name ="Employee First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string LastName{ get; set; }

        public int PositionID { get; set; }
        public string PositionTitle { get; set; }
    }
}
