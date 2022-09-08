using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels
{
    public class DogReportDetails
    {
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }

        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }

        [Display(Name = "Dog Name")]
        public string Name { get; set; }

        [Display(Name = "Breed Name")]
        public string BreedName { get; set; }
        [Display(Name = "Dog Age")]
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public string TempermentType { get; set; }
        public string InjurySeverityType { get; set; }
        public string EventDescription { get; set; }
        public decimal CaptureWorth { get; set; }

        public int BreedID { get; set; }
        // public int PositionID { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}