using PopsAnimalControl_MVC.Models.Enums;
using PopsAnimalControl_MVC.Models.PokemonReportData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels
{
    public class PokemonCreate
    {

        [Required]
        public string PokemonBirthName { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        public string PokemonTypeName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }

        [Required]
        public bool HasCollarIdentification { get; set; }

        [Required]
        public bool HasChipIdentification { get; set; }

        [Required]
        public Temperment TempermentType { get; set; }

        [Required]
        public InjuryServerityType InjuryServerityType { get; set; }
        public decimal CaptureWorth { get; set; }

        [Required]
        public int ReportID { get; set; }
        public PokemonReport PokemonReport { get; set; }
    }
}