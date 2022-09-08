using PAC.Data.Contracts.IEmployees.IPositions;
using PAC.Data.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Employees.Positions
{
    public class Position : IPosition
    {
        [Key]
        public int PositionID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid OwnerID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int AvailablePositionCount { get; set; }
    }
}
