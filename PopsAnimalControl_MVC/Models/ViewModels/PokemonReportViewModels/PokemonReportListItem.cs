using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels
{
    public class PokemonReportListItem
    {
        public int ReportID { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}