using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.PokemonModels
{
    public class PokemonListItem
    {
        public int id { get; set; }
        public string PokemonBreedName { get; set; }
        public string PokemonBirthName { get; set; }
    }
}
