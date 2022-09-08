using PAC.Data.Contracts.IAnimals.IPokemons.IPokeIdentifiables;
using PAC.Data.Contracts.IAnimals.IPokemons.IPokeNameables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals.IPokemons
{
    public interface IPokemon : IAnimal, IPokeIdentifiable,IPokeNameable
    {
    }
}
