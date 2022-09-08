using PAC.Data.Contracts.IEmployees;
using PAC.Data.Employees.Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PAC.Data.DogCatchers
{
    public class DogCatcher:IEmployee
    {
        public Guid OwnerID { get; set; }
        
        [Key]
        public int EmployeeID { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set ; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        
        public bool isFired { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set ; }
       

        [ForeignKey(nameof(Position))]
        public int PositionID { get; set ; }
        public Position Position { get; set; }

        [DisplayName("UploadFile")]
        public string ImageSource { get; set; }//image path
        
        [NotMapped]
        public HttpPostedFileBase ImageFile{ get; set; }
    }
}
