using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatCatcherViewModels
{
    public class CatCatcherCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PositionID { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public string ImageSource { get; set; }
        public List<ApplicantListItem> CatCatcherApplicants { get; set; } = new List<ApplicantListItem>();
        public List<DepartmentPositionListItem> CatCatcherDepartments { get; set; } = new List<DepartmentPositionListItem>();

    }
}