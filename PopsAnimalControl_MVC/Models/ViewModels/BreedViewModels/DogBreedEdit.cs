using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.BreedViewModels
{
    public class DogBreedEdit
    {
        public int BreedID { get; set; }

        public string BreedName { get; set; }

        public string Section { get; set; }

        public string Country { get; set; }
    }
}