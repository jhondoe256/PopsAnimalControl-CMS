using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatBreedViewModels
{
    public class CatBreedEdit
    {
        public int Cat_BreedID { get; set; }
        public string Breed { get; set; }
        public string LocationAndOrigin { get; set; }
        public string Type { get; set; }
        public string BodyType { get; set; }
        public string CoatTypeAndLength { get; set; }
        public string CoatPattern { get; set; }
    }
}