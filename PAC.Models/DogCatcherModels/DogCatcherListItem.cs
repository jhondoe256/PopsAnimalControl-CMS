using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.DogCatcherModels
{
    public class DogCatcherListItem
    {
        public int EmployeeID { get; set; }
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int PositionID { get; set; }

        [Display(Name ="Position Title")]
        public string PositionTitle { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}
