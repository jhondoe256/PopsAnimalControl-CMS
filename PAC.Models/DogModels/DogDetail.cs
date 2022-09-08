using PAC.Data.Animals.Breeds;
using PAC.Data.Animals.ENUMS;
using PAC.Data.Reports.DogReports;
using PAC.Models.AnimalModels.BreedModels.DogBreeds;
using PAC.Models.ReportModels.DogReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.DogModels
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
        public DogReportListItem DogReport{ get; set; }
    }
}
