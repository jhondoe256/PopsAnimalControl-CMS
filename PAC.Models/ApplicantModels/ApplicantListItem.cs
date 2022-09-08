using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ApplicantModels
{
    public class ApplicantListItem
    {
        public int ID { get; set; }

        [Display(Name = "Applicant First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Applicant Last Name")]
        public string LastName { get; set; }

        public int DepartmentID { get; set; }

        [Display(Name = "Department of intrest")]
        public string DepartmentOfIntrest { get; set; }

    }
}
