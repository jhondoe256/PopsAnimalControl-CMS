using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels
{
    public class DepartmentCreate
    {
        [Required]
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}