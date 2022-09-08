using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels
{
    public class PokemonReportEdit
    {
        [Required]
        public int ReportID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PokemonBirthName { get; set; }
        public int Age { get; set; }
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
        //  public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string EventDescription { get; set; }
        public int PositionID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}