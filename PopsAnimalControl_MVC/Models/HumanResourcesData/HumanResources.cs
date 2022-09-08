using PopsAnimalControl_MVC.Models.DataModels.PositionData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.HumanResourcesData
{
    public class HumanResources
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; }
        public bool isFired { get; }

        [ForeignKey(nameof(Position))]
        public int PositionID { get; set; }
        public Position Position { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public Guid OwnerID { get; set; }

        public string ImageSource { get; set; }
    }
}