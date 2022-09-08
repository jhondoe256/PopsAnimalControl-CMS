using PopsAnimalControl_MVC.Models.ViewModels.BreedViewModels;
using PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DogViewModels
{
    public class DogDetail
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public string TempermentType { get; set; }
        public string InjuryServerityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int BreedID { get; set; }
        public DogBreedListItem Breed { get; set; }
        public int ID { get; set; }
        public DogReportListItem DogReport { get; set; }
    }
}