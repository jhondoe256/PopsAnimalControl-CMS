using PAC.Data.Contracts.IAnimals.IPokemons;
using PAC.Data.Contracts.IReports.IEventDescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IReports.IPokeReports
{
    public interface IPokeReport:IReport,IPokemon,IEventDescription
    {
    }
}
