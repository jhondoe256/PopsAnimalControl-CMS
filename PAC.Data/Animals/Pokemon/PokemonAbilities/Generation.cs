using PAC.Data.Contracts.IAnimals.IPokemons.IPokeIdentifiables;
using PAC.Data.Contracts.IAnimals.IPokemons.IPokeNameables;
using System.Collections.Generic;

namespace PAC.Data.Animals.Pokemon.PokemonAbilities
{
    public class Generation : IPokeIdentifiable,IPokeNameable
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Move> moves { get; set; } = new List<Move>();
    }
}