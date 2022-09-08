using PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DogCatcherViewModels
{
    public class DogCatcherEdit
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //   public int PositionID { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}