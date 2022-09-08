using PopsAnimalControl_MVC.Models.DataModels.DepartmentData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.DataModels.ApplicantData
{
    public class Applicant
    {
        [Key]
        public int ID { get; set; }
        public Guid OwnerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        [ForeignKey(nameof(Department))]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Social Security Number")]
        [MaxLength(11, ErrorMessage = "Too many Values")]
        public string SocialSecurityNumber { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyAReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyAAddress { get; set; }

        public DateTime? CompanyADateStarted { get; set; }
        public DateTime? CompanyADateEnded { get; set; }

        public bool CompanyAMayWeContactThisEmployer { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyBReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyBAddress { get; set; }

        public DateTime? CompanyBDateStarted { get; set; }
        public DateTime? CompanyBDateEnded { get; set; }

        public bool CompanyBMayWeContactThisEmployer { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        public string CompanyCReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        public string CompanyCAddress { get; set; }

        public DateTime? CompanyCDateStarted { get; set; }
        public DateTime? CompanyCDateEnded { get; set; }

        public bool CompanyCMayWeContactThisEmployer { get; set; }
    }
}