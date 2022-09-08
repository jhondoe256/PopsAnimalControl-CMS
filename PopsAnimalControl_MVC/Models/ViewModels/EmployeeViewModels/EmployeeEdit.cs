using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeEdit
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public bool IsFired { get; }
        public DateTime ModificationionDate { get; set; }
    }
}