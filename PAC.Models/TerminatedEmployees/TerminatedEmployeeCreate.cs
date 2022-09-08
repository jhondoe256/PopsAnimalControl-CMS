using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.TerminatedEmployees
{
    public class TerminatedEmployeeCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfTermination { get; set; }
        [Required]
        public int PositionID { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageSource { get; set; }
    }
}
