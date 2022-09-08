using PAC.Data.Contracts.IAnimals.IBreedables;
using PAC.Data.Contracts.IAnimals.IIdentifiables;
using PAC.Data.Contracts.IAnimals.INameables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals.ICats
{
    public interface ICat:IAnimal,INameable,IIdentifiable
    {
    }
}
