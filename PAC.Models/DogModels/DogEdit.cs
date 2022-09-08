using PAC.Data.Animals.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.DogModels
{
    public class DogEdit
    {
        public int ID { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjuryServerityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int BreedID { get; set; }

        public string Name { get; set; }
        public int ReportID { get; set; }
    }
}
