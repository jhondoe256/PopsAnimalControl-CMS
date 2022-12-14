using PopsAnimalControl_Console_UI.DataModels.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.DataModels
{
    public class DogCatcher:IEmployee
    {
        public Guid OwnerID { get; set; }

        [Key]
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public bool isFired { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }


        [ForeignKey(nameof(Position))]
        public int PositionID { get; set; }
        public Position Position { get; set; }
        public string ImageSource { get ; set ; }
    }
}
