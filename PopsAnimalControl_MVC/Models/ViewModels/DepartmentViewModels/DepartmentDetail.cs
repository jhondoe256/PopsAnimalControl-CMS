using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels
{
    public class DepartmentDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public virtual List<DepartmentDetailsEmployeeListItem> Employees { get; set; } = new List<DepartmentDetailsEmployeeListItem>();
        public List<DepartmentPositionListItem> Department_Positions { get; set; } = new List<DepartmentPositionListItem>();
    }
}