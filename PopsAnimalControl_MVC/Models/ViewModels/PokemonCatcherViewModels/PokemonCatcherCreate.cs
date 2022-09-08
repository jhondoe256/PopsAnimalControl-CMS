using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonCatcherViewModels
{
    public class PokemonCatcherCreate
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
        public List<ApplicantListItem> PokemonCatcherApplicants { get; set; } = new List<ApplicantListItem>();
        public List<DepartmentPositionListItem> PokemonCatcherDepartments { get; set; } = new List<DepartmentPositionListItem>();

    }
}