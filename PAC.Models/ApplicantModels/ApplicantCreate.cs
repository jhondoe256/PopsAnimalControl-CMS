using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ApplicantModels
{
    public class ApplicantCreate
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int DepartmentID { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        [Display(Name = "Social Security Number")]
        [MaxLength(11, ErrorMessage = "Too many Values")]
        public string SocialSecurityNumber { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyAAddress { get; set; }

        public DateTime? CompanyADateStarted { get; set; }
        public DateTime? CompanyADateEnded { get; set; }

        [Required]
        public bool CompanyAMayWeContactThisEmployer { get; set; }


        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyBAddress { get; set; }

        public DateTime? CompanyBDateStarted { get; set; }
        public DateTime? CompanyBDateEnded { get; set; }

        [Required]
        public bool CompanyBMayWeContactThisEmployer { get; set; }


        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyCAddress { get; set; }

        public DateTime? CompanyCDateStarted { get; set; }
        public DateTime? CompanyCDateEnded { get; set; }

        [Required]
        public bool CompanyCMayWeContactThisEmployer { get; set; }
    }
}
