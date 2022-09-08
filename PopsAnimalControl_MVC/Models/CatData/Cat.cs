using PopsAnimalControl_MVC.Models.CatData.CatBreeds;
using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.CatData
{
    public class Cat
    {
        public Guid OwnerID { get; set; }

        [Key]
        public int ID { get; set; }

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
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfCapture { get; set; }

        public bool HasCollarIdentification { get; set; }
        public bool HasChipIdentification { get; set; }

        public Temperment TempermentType { get; set; }
        public InjuryServerityType InjurySeverityType { get; set; }

        public decimal CaptureWorth { get; set; }

        [ForeignKey(nameof(CatBreedType))]
        public int CatBreedID { get; set; }
        public CatBreedType CatBreedType { get; set; }
    }
}