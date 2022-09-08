using PAC.Data.Animals.ENUMS;
using PAC.Data.Animals.Pokemon.PokemonAbilities;
using PAC.Models.ReportModels.PokemonReportModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PokemonModels
{
    public class PokemonDetail
    {
        [Display(Name = "Pokemon Name")]
        public string name { get; set; }
        [Display(Name = "Pokemon Birth Name")]
        public string PokemonBirthName { get; set; }
        public int PokeID { get; set; }
        public List<PokemonForm> forms { get; set; } = new List<PokemonForm>();
        public List<PokemonAbility> abilities { get; set; } = new List<PokemonAbility>();
        public List<PokemonMove> moves { get; set; } = new List<PokemonMove>();
        public int Age
        {
            get;set;
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
