using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ManagementModels
{
    public class ManagementCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PositionID { get; set; }
        [Required]
        public int DepartmetID { get; set; }
        public string ImageSource { get; set; }
    }
}
