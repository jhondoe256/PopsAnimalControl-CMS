using PAC.Data.Animals.ENUMS;
using PAC.Data.Contracts.IReports;
using PAC.Data.Contracts.IReports.IPokeReports;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Reports.PokemonReports
{
    public class PokemonReport : IPokeReport
    {
        [Key]
        public int ReportID { get; set; }
        public Guid OwnerID { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PokemonBirthName { get; set; }
        public int Age 
        {
            get
            {
                if (HasChipIdentification || HasCollarIdentification)
                {
                    var mod = (DateTime)DateOfBirth;
                    if (mod == null)
                    {
                        return 0;
                    }
                    else
                    {
                        var age = DateTime.Now.Year - mod.Year;
                        return age;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public DateTime? DateOfBirth { get; set ; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string EventDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
    }
}
