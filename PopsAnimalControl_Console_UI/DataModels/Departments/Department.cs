using PopsAnimalControl_Console_UI.DataModels.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.DataModels.Departments
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<IEmployee> Employees { get; set; } = new List<IEmployee>();
        public virtual List<Position> Department_Positions { get; set; } = new List<Position>();
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public Guid OwnerID { get; set; }
    }
}
