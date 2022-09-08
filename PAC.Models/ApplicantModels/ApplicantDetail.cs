using PAC.Data.Departments;
using PAC.Data.Employees.Applicants.References;
using PAC.Models.DepartmentModels.Department_Positions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ApplicantModels
{
    public class ApplicantDetail
    {
        public int ID { get; set; }

        [Display(Name = "Applicant First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Applicant Last Name")]
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Social Security Number")]
        [MaxLength(11, ErrorMessage = "Too many Values")]
        public string SocialSecurityNumber { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name ="Reference 1 Company Name")]
        public string CompanyAName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 1 First Name:")]
        public string CompanyAReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 1 Last Name:")]
        public string CompanyAReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Reference 1  Company Address:")]
        public string CompanyAAddress { get; set; }
        [Display(Name = "Reference 1 Company Date Started:")]
        public DateTime? CompanyADateStarted { get; set; }
        [Display(Name = "Reference 1 Company Date Ended:")]
        public DateTime? CompanyADateEnded { get; set; }
        [Display(Name = "Reference 1, Can we contact this employer?")]
        public bool CompanyAMayWeContactThisEmployer { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 2 Company Name:")]
        public string CompanyBName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 2 First Name:")]
        public string CompanyBReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 2 Last Name:")]
        public string CompanyBReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Reference 2 Company Address:")]
        public string CompanyBAddress { get; set; }
        [Display(Name = "Reference 2 Company Date Started:")]
        public DateTime? CompanyBDateStarted { get; set; }
        [Display(Name = "Reference 2 Company Date Ended:")]
        public DateTime? CompanyBDateEnded { get; set; }
        [Display(Name = "Reference 2, Can we contact this employer?")]
        public bool CompanyBMayWeContactThisEmployer { get; set; }


        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 3 Company Name:")]
        public string CompanyCName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 3 First Name:")]
        public string CompanyCReferenceFirstName { get; set; }

        [MaxLength(200, ErrorMessage = "You have exceeded the Max Limit Of Characters (200)")]
        [Display(Name = "Reference 3 Last Name:")]
        public string CompanyCReferenceLastName { get; set; }

        [MaxLength(400, ErrorMessage = "You have exceeded the Max Limit Of Characters (400)")]
        [Display(Name = "Reference 3 Company Address:")]
        public string CompanyCAddress { get; set; }
        [Display(Name = "Reference 3 Company Date Started:")]
        public DateTime? CompanyCDateStarted { get; set; }
        [Display(Name = "Reference 3 Company Date Ended:")]
        public DateTime? CompanyCDateEnded { get; set; }
        [Display(Name = "Reference 3, Can we contact this employer?")]
        public bool CompanyCMayWeContactThisEmployer { get; set; }
    }
}

