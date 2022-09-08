using PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonCatcherViewModels
{
    public class PokemonCatcherDetail
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PositionListItem Position { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}