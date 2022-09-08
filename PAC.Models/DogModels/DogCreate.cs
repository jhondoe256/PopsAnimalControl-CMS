using PAC.Data.Animals.Breeds;
using PAC.Data.Animals.ENUMS;
using PAC.Data.Reports.DogReports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.DogModels
{
    public class DogCreate
    {
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        [Required]
        public bool HasCollarIdentification { get; set; }
        [Required]
        public bool HasChipIdentification { get; set; }
        [Required]
        public Temperment TempermentType { get; set; }
        [Required]
        public InjuryServerityType InjurtServerityType { get; set; }
        [Required]
        public decimal CaptureWorth { get; set; }
        public int BreedID { get; set; }
        public Breed Breed { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ReportID { get; set; }
        public DogReport DogReport{ get; set; }
    }
}
