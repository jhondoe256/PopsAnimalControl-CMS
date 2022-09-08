using Microsoft.AspNet.Identity;
using PAC.Models.DepartmentModels;
using PAC.Services.DepartmentServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Department_Controller
{
    //MANAGEMENT/ADMINS ARE ONLY ALLOWED TO USE THIS
    public class DepartmentController : ApiController
    {
        private DepartmentService CreateDepartmentService(Guid guid)
        {
            // var userId = Guid.Parse(User.Identity.GetUserId());
            // var svc = new DepartmentService(userId);
            var svc = new DepartmentService(guid);
            return svc;
        }
        private DepartmentService CreateDepartmentService()
        {
            var svc = new DepartmentService();
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateDepartmentService();
            var departments = await svc.GetDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateDepartmentService();
            var department = await svc.GetDepartmentDetailsAsync(id);
            if (department is null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(DepartmentCreate department)
        {
            if (department is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDepartmentService();
            var success = await svc.CreateDepartmentAsync(department);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] DepartmentEdit model, [FromUri] int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            if (model.ID!=id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid==false)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDepartmentService();
            var success = await svc.UpdateDepartmentAsync(model, id);
            if (success)
            {
                return Ok($"Department: {model.Name} was Updated.");
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateDepartmentService();
            var success = await svc.DeleteDepartmentAsync(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Department/DAllEmployees/{id}")]
        public async Task<IHttpActionResult> DeleteAllEmployees(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateDepartmentService();
            var success = await svc.RemoveAllEmployeesFromDepartment(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        
        [HttpPost]
        [Route("api/Department/gInfo/{email}")]
        public  async Task<IHttpActionResult> GetGuid(string email, DepartmentCreate department)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc= CreateDepartmentService(guid);
            if (department is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await svc.CreateDepartmentAsync(department);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/Departments/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDepartmentService(guid);
            var departments = await svc.GetDepartmentsAsync();
            return Ok(departments);
        }
        [HttpGet]
        [Route("api/Departments/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDepartmentService(guid);
            var department = await svc.GetDepartmentDetailsAsync(id);
            return Ok(department);
        }
        [HttpPut]
        [Route("api/Departments/Update/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, DepartmentEdit department, int id)
        {
            if (id<1 || id!=department.ID)
            {
                return BadRequest();
            }
            if (ModelState.IsValid==false)
            {
                return BadRequest();
            }
            
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDepartmentService(guid);
            var success = await svc.UpdateDepartmentAsync(department,id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Departments/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email,int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDepartmentService(guid);
            var success = await svc.DeleteDepartmentAsync(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
