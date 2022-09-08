using PAC.Data.Animals.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ReportModels.CatReportModels
{
    public class CatReportCreate
    {

        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Employee First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Employee Last Name")]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }

        [Required]
        public bool HasCollarIdentification { get; set; }

        [Required]
        public bool HasChipIdentification { get; set; }

        [Required]
        public Temperment TempermentType { get; set; }

        [Required]
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }//this is autoIncremented via the catID database lookup

        public int CatBreedID { get; set; }

        [Display(Name = "Cat Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        //  public int PositionID { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
