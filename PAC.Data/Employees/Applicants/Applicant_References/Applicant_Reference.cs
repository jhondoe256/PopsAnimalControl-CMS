using PAC.Data.Employees.Applicants.References;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Data.Employees.Applicants.Applicant_References
{
    public class Applicant_Reference
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Applicant))]
        public int ApplicantID { get; set; }
        public Applicant Applicant { get; set; }

        [ForeignKey(nameof(Reference))]
        public int ReferenceID { get; set; }
        public Reference Reference { get; set; }
    }
}
