using PopsAnimalControl_MVC.Models.Enums;
using PopsAnimalControl_MVC.Models.ViewModels.CatBreedViewModels;
using PopsAnimalControl_MVC.Models.ViewModels.CatReportViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatViewModels
{
    public class CatDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public CatBreedListItem Breed { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public CatReportListItem CatReport { get; set; }
        public DateTime? DateOfCapture { get; set; }
    }
}