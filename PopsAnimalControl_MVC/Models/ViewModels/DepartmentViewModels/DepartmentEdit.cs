using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels
{
    public class DepartmentEdit
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}