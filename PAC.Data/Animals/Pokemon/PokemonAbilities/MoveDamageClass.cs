using PAC.Data.Contracts.IAnimals.IPokemons.IPokeIdentifiables;
using PAC.Data.Contracts.IAnimals.IPokemons.IPokeNameables;
using System.Collections.Generic;

namespace PAC.Data.Animals.Pokemon.PokemonAbilities
{
    public class MoveDamageClass : IPokeIdentifiable, IPokeNameable
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Description> descriptions{ get; set; }
        public List<Move> moves{ get; set; }
    }
}