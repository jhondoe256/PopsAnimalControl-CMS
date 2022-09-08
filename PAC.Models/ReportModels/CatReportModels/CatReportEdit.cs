using PAC.Data.Animals.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ReportModels.CatReportModels
{
    public class CatReportEdit
    {
        public int ReportID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int ID { get; set; }//catID
        public int CatBreedID { get; set; }
        public string Name { get; set; }
        public string EventDescription { get; set; }
        public int EmployeeID { get; set; }
        public int PositionID { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}
