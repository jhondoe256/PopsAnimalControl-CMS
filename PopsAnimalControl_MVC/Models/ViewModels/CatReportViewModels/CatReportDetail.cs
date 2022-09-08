using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatReportViewModels
{
    public class CatReportDetail
    {

        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public int Age { get; set; }

        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }

        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }//this is autoIncremented via the catID database lookup

        //   [Display(Name = "CatID")]
        // public int ID { get; set; }

        [Display(Name = "Cat Name")]
        public string Name { get; set; }

        public int CatBreedID { get; set; }

        [Display(Name = "Breed Name")]
        public string BreedName { get; set; }


        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        //   public int PositionID { get; set; }

        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}