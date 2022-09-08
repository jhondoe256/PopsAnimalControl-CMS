using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.CatCatcherViewModels
{
    public class CatCatcherListItem
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
    }
}