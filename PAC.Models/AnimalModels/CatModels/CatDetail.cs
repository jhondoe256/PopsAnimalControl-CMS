using PAC.Data.Animals.Breeds;
using PAC.Data.Animals.ENUMS;
using PAC.Data.Contracts.IReports;
using PAC.Data.Reports;
using PAC.Data.Reports.CatReports;
using PAC.Models.AnimalModels.BreedModels.CatBreeds;
using PAC.Models.ReportModels.CatReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.AnimalModels.CatModels
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
