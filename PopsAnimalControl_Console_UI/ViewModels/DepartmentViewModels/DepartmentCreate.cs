using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.DepartmentViewModels
{
    public class DepartmentCreate
    {
        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
