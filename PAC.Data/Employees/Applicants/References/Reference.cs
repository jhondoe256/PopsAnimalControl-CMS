using PAC.Data.Contracts.IEmployees.IHuman_R.IReferences;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Employees.Applicants.References
{
    public class Reference : IReference
    {
        [Key]
        public int ReferenceID { get; set; }
       
        [MaxLength(200,ErrorMessage ="You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyName { get; set; }
        
        [MaxLength(200,ErrorMessage ="You have exceeded the Max Limit Of Characters (200)")]
        public string ReferenceFirstName { get; set; }
        
        [MaxLength(200,ErrorMessage ="You have exceeded the Max Limit Of Characters (200)")]
        public string ReferenceLastName { get; set; }
        
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string Address { get; set; }
       
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnded { get; set; }
       
        public bool MayWeContactThisEmployer { get; set; }
    }
}
