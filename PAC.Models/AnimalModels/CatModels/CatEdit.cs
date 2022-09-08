using PAC.Data.Animals.Breeds;
using PAC.Data.Animals.ENUMS;
using PAC.Data.Contracts.IReports;
using PAC.Data.Contracts.IReports.ICatReports;
using PAC.Data.Reports;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.AnimalModels.CatModels
{
    public class CatEdit
    {
        public int ID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int BreedID { get; set; }
       
        public string Name { get; set; }
        public int ReportID { get; set; }
       

    }
}
