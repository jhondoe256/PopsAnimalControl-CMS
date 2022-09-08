using PAC.Data.Animals.Breeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals.IBreedables
{
    public interface IBreedable
    {
        int BreedID { get; set; }
        Breed Breed { get; set; }
    }
}
