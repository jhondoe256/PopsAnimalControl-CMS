using PopsAnimalControl_MVC.Models.DogData.Breeds;
using PopsAnimalControl_MVC.Models.DogReportData;
using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DogViewModels
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
        public DogReport DogReport { get; set; }
    }
}