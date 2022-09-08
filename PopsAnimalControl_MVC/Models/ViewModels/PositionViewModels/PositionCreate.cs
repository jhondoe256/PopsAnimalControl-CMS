using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels
{
    public class PositionCreate
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Avalilable Positions:")]
        public int AvailablePositionCount { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public DateTime CreationDate { get; set; }
    }
}