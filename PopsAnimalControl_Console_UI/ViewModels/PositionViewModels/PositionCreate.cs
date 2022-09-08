using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.PositionViewModels
{
    public class PositionCreate
    {
        public string Name { get; set; }

        public int AvailablePositionCount { get; set; }

        public int DepartmentID { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
