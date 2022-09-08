using PAC.Data.Contracts.IAnimals.IPokemons.IPokeIdentifiables;
using PAC.Data.Contracts.IAnimals.IPokemons.IPokeNameables;

namespace PAC.Data.Animals.Pokemon.PokemonAbilities
{
    public class Ability : IPokeNameable
    {
        public string name { get; set; }
      //  public string id { get; set; }
      //  public Generation generation { get; set; }
    }
}