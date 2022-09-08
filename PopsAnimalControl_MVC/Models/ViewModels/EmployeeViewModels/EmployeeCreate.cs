using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImageSource { get; set; }
    }
}