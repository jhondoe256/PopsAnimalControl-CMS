using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels
{
    public class DogReportEdit
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
        public int ID { get; set; }//dogID
        public int BreedID { get; set; }
        public string Name { get; set; }
        public string EventDescription { get; set; }
        public int EmployeeID { get; set; }
        //    public int PositionID { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}