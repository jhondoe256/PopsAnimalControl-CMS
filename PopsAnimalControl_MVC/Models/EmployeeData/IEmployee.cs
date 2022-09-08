using PopsAnimalControl_MVC.Models.DataModels.PositionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.EmployeeData
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