using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PositionModels
{
    public class PositionCreate
    {
        [Required]
        public string Name { get; set; }

        [Display(Name ="Avalilable Positions:")]
        public int AvailablePositionCount { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
