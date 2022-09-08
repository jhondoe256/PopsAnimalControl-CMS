using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.DogData.Breeds
{
    public class Breed
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