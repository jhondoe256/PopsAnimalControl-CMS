using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels
{
    public class PositionDetail
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }

        [Display(Name = "Avalilable Positions:")]
        public int AvailablePositionCount { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}