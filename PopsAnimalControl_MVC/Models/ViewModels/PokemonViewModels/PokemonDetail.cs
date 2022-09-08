using PopsAnimalControl_MVC.Models.Enums;
using PopsAnimalControl_MVC.Models.PokemonData.PokemonAbilities;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels
{
    public class PokemonDetail
    {
        [Display(Name = "Pokemon Name")]
        public string name { get; set; }
        public string PokemonBirthName { get; set; }
        public int PokeID { get; set; }
        public List<PokemonForm> forms { get; set; } = new List<PokemonForm>();
        public List<PokemonAbility> abilities { get; set; } = new List<PokemonAbility>();
        public List<PokemonMove> moves { get; set; } = new List<PokemonMove>();
        public int Age
        {
            get; set;
        }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }//convert Temperment (type) to string
        public InjuryServerityType InjurySeverityType { get; set; }//convert InjurySeverity (type) to string
        public decimal CaptureWorth { get; set; }
        public PokemonReportListItem PokeReport { get; set; }
    }
}