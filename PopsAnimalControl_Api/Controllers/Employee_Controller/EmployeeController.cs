using Microsoft.AspNet.Identity;
using PAC.Services.EmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Employee_Controller
{
    public class EmployeeController : ApiController
    {
        private EmployeeService CreateEmployeeService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new EmployeeService(user);
            return svc;
        }
        [HttpDelete]
        [Route("api/Employee/RemoveAll/{departmentID}")]
        public IHttpActionResult DeleteAllEmployees(int departmentID)
        {
            if (departmentID<1)
            {
                return BadRequest();
            }
            var svc = CreateEmployeeService();
            var success = svc.DeleteAllEmployeesViaDepartment(departmentID);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
