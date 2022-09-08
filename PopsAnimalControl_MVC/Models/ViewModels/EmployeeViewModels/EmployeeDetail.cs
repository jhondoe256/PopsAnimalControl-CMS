using PopsAnimalControl_MVC.Models.DataModels.PositionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.EmployeeViewModels
{
    public class EmployeeDetail
    {
        public int EmployeeID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string FullName { get; }

        public int PositionID { get; set; }
        public Position Position { get; set; }

        public bool isFired { get; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}