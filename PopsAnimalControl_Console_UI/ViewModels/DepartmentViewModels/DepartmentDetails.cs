using PopsAnimalControl_Console_UI.ViewModels.DepartmentViewModels.Department_Positions;
using PopsAnimalControl_Console_UI.ViewModels.DepartmentViewModels.DepartmentDetailsEmployeeListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.DepartmentViewModels
{
    public class DepartmentDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationionDate { get; set; }
        public virtual List<DepartmentDetailsEmployeeListItem> Employees { get; set; } = new List<DepartmentDetailsEmployeeListItem>();
        public List<DepartmentPositionListItem> Department_Positions { get; set; } = new List<DepartmentPositionListItem>();
    }
}
