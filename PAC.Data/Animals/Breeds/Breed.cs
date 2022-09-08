using PAC.Data.Contracts.IAnimals.IBreedables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Animals.Breeds
{
    public class Breed : IBreed
    {
        public Guid OwnerID { get; set; }
        public int BreedID { get; set; }
        
        [Required]
        public string BreedName { get; set; }
        
        public string Section { get; set; }
        
        public string Country { get; set; }

        public Breed(string breedName, string section, string country)
        {
            BreedName = breedName;
            Section = section;
            Country = country;
        }


        public Breed()
        {

        }
    }
}
