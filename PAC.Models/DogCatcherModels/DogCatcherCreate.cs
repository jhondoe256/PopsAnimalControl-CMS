using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PAC.Models.DogCatcherModels
{
    public class DogCatcherCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PositionID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public DateTime CreationDate { get; set; }
     
      
    }
}
