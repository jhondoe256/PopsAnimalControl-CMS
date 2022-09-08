using PopsAnimalControl_MVC.Models.DataModels.DepartmentData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.DataModels.PositionData
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public Guid OwnerID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int AvailablePositionCount { get; set; }
    }
}