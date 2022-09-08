using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Animals.Breeds
{
    public class CatBreedType
    {
        public Guid OwnerID { get; set; }
        [Key]
        public int ID { get; set; }

        [Required]
        public string BreedName { get; set; }

        public string LocationAndOrigin { get; set; }

        public string Type { get; set; }
        public string BodyType { get; set; }
        public string CoatTypeAndLength { get; set; }
        public string CoatPattern { get; set; }

       
    }
}
