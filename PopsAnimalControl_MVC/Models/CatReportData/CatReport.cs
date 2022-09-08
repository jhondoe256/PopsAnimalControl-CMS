using PopsAnimalControl_MVC.Models.CatData.CatBreeds;
using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.CatReportData
{
    public class CatReport
    {
        [Key]
        public int ReportID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

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
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }
        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }
        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }
        public decimal CaptureWorth { get; set; }

        //[Display(Name ="CatID")]
        //public int ID { get; set; }

        [ForeignKey(nameof(CatBreed))]
        public int CatBreedID { get; set; }
        public CatBreedType CatBreed { get; set; }

        [Display(Name = "Cat Name")]
        public string Name { get; set; }

        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }
        public int EmployeeID { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public Guid OwnerID { get; set; }
    }
}