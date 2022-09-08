using PopsAnimalControl_MVC.Models.DataModels.PositionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.EmployeeData
{
    public class Employee : IEmployee
    {
        public Guid OwnerID { get; set; }
        public int EmployeeID { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
       
        public int PositionID { get; set; }
        public Position Position { get; set; }

        public bool isFired { get; }

        public string ImageSource { get; set; }
    }
}