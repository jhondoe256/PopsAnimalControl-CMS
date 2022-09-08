using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels
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
        [Display(Name = "Company Name:")]
        public string CompanyAName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference First Name:")]
        public string CompanyAReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference Last Name:")]
        public string CompanyAReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Address:")]
        public string CompanyAAddress { get; set; }
        [Display(Name = "Start Date:")]
        public DateTime? CompanyADateStarted { get; set; }
        [Display(Name = "End Date:")]
        public DateTime? CompanyADateEnded { get; set; }

        [Required]
        [Display(Name = "May we contact this Employer?")]
        public bool CompanyAMayWeContactThisEmployer { get; set; }


        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Company Name:")]
        public string CompanyBName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference First Name:")]
        public string CompanyBReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference Last Name:")]
        public string CompanyBReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Address:")]
        public string CompanyBAddress { get; set; }
        [Display(Name = "Start Date:")]
        public DateTime? CompanyBDateStarted { get; set; }
        [Display(Name = "End Date:")]
        public DateTime? CompanyBDateEnded { get; set; }

        [Required]
        [Display(Name ="May we contact this Employer?")]
        public bool CompanyBMayWeContactThisEmployer { get; set; }


        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Company Name:")]
        public string CompanyCName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference First Name:")]
        public string CompanyCReferenceFirstName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference Last Name:")]
        public string CompanyCReferenceLastName { get; set; }

        [Required]
        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Address:")]
        public string CompanyCAddress { get; set; }

        [Display(Name = "Start Date:")]
        public DateTime? CompanyCDateStarted { get; set; }
        [Display(Name = "End Date:")]
        public DateTime? CompanyCDateEnded { get; set; }

        [Required]
        [Display(Name = "May we contact this Employer?")]
        public bool CompanyCMayWeContactThisEmployer { get; set; }
    }
}