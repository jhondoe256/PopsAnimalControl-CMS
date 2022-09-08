using PopsAnimalControl_Console_UI.ViewModels.PositionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.DogCatcherViewModels
{
    public class DogCatcherDetail
    {
        public int EmployeeID { get; set; }

        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PositionListItem Position { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }

    }
}
