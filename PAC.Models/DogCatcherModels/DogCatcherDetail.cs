using PAC.Data.Employees.Positions;
using PAC.Models.PositionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PAC.Models.DogCatcherModels
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

        [DisplayName("UploadFile")]
        public string ImageSource { get; set; }//image path

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
