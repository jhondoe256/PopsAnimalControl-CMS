using PAC.Data.Animals.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ReportModels.PokemonReportModels
{
    public class PokemonReportDetails
    {
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        
        [Display(Name = "Employee First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Employee Last Name")]
        public string LastName { get; set; }
       // public int PositionID { get; set; }
        [Display(Name = "Position Title")]
        public string PositionTitle { get; set; }
        public string PokemonBirthName { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public string TempermentType { get; set; }
        public string InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public string name { get; set; }
        public string EventDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}
