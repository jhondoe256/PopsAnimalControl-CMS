using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatViewModels
{
    public class CatCreate
    {
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int CatBreedID { get; set; }
        //  public CatBreedType Breed { get; set; }
        public string Name { get; set; }
        public int ReportID { get; set; }
        //   public CatReport CatReport { get; set; }
    }
}