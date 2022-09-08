using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.DogCatcherViewModels
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
