using PAC.Data.Animals.Pokemon.PokemonAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals.IPokemons.IPoke_s
{
    public interface IPoke
    {
        int height { get; set; }
        int weight { get; set; }
        List<PokemonAbility> abilities { get; set; }
        List<PokemonForm> forms { get; set; } 

        List<PokemonMove> moves { get; set; } 
    }
}
