using PAC.Data.Animals.ENUMS;
using PAC.Data.Contracts.IReports;
using PAC.Data.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Contracts.IAnimals
{
    public interface IAnimal
    {
        Guid OwnerID { get; set; }
        int Age { get; }
        DateTime? DateOfBirth { get; set; }
        DateTime? DateOfCapture { get; set; }
        bool HasCollarIdentification { get; set; }
        bool HasChipIdentification { get; set; }
        Temperment TempermentType { get; set; }
        InjuryServerityType InjurySeverityType { get; set; }
        decimal CaptureWorth { get; set; }
       
        
    }
}
