using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatCatcherViewModels
{
    public class CatCatcherEdit
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //    public int PositionID { get; set; }
        //    public int DepartmentID { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}