﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ApplicantModels
{
    public class ApplicantEdit
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentID { get; set; }
        public string Address { get; set; }

        [Display(Name = "Social Security Number")]
        [MaxLength(11, ErrorMessage = "Too many Values")]
        public string SocialSecurityNumber { get; set; }
      
    }
}
