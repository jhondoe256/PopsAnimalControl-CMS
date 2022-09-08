using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.PokemonData.PokemonAbilities
{
    public class Generation
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Move> moves { get; set; } = new List<Move>();
    }
}