using PopsAnimalControl_Console_UI.DataModels.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.DataModels
{
    public interface IEmployee
    {
        Guid OwnerID { get; set; }
        int EmployeeID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        int PositionID { get; set; }
        Position Position { get; set; }
        bool isFired { get; }
        string ImageSource { get; set; }
    }
}
