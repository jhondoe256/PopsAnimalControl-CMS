using PAC.Data.Animals.ENUMS;
using PAC.Data.Animals.Pokemon.PokemonAbilities;
using PAC.Data.Reports.PokemonReports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PokemonModels
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
