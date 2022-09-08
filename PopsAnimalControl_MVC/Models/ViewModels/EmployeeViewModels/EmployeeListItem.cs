using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeListItem
    {
        public int EmployeeID { get; set; }
        public string FullName { get; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }
}