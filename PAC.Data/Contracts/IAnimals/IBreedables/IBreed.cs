using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals.IBreedables
{
    public interface IBreed
    {
        int BreedID { get; set; }
        string BreedName { get; set; }
        string Section { get; set; }
        string Country { get; set; }
    }
}
