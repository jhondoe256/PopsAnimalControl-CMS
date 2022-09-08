using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels
{
    public class ApplicantListItem
    {
        public int ID { get; set; }

        [Display(Name = "Applicant First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Applicant Last Name")]
        public string LastName { get; set; }

        public int DepartmentID { get; set; } //WATCH OUT!!!

        [Display(Name = "Department of intrest")]
        public string DepartmentOfIntrest { get; set; }
    }
}