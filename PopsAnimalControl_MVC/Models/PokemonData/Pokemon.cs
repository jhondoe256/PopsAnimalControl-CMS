using PopsAnimalControl_MVC.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.PokemonData
{
    public class Pokemon
    {
        [Key]
        public int PokeID { get; set; }
        public string PokemonBirthName { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "ID")]
        public int id { get; set; }
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

        //   [ForeignKey(nameof(Report))]
        //    public int ReportID { get; set; }
        //    public Report Report { get; set; }
        public Guid OwnerID { get; set; }
    }
}