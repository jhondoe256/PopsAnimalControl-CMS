﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.TerminatedEmployees
{
    public class TerminatedEmployeeEdit
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionID { get; set; }
        public DateTime ModificationionDate { get; set; }
    }
}
