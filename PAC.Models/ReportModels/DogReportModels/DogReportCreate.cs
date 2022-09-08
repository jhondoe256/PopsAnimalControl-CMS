using PAC.Data.Animals.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ReportModels.DogReportModels
{
    public class DogReportCreate
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
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
        public decimal CaptureWorth { get; set; }
        public int BreedID { get; set; }
        public string Name { get; set; }
        [Required]
        public string EventDescription { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
