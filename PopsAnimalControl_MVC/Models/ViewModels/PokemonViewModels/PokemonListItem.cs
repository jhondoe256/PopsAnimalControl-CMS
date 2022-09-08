using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels
{
    public class PokemonListItem
    {
        public int id { get; set; }
        [Display(Name = "Pokemon Breed Name")]
        public string PokemonBreedName { get; set; }
        
        [Display(Name = "Pokemon Birth Name")]
        public string PokemonBirthName { get; set; }
    }
}