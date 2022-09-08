using PAC.Data.Contracts.ITerminated;
using PAC.Data.Departments;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.TerminatedEmployees
{
    public class TerminatedEmployee : ITerminatedEmployee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        public bool isFired { get; }
        public DateTime DateOfTermination { get; set; }
        public int RehireableChances { get; set; } = 3;
        public bool IsRehaireable 
        {
            get 
            {
                if (RehireableChances>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            
        }

        [ForeignKey(nameof(Position))]
        public int PositionID { get; set; }
        public Position Position { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public Guid OwnerID { get; set; }
        public string ImageSource { get; set; }

    }
}
