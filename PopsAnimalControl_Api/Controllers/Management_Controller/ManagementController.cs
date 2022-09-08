using Microsoft.AspNet.Identity;
using PAC.Models.ManagementModels;
using PAC.Services.ManagementServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Management_Controller
{
    public class ManagementController : ApiController
    {
        private ManagementService CreateManagementService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ManagementService(userId);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateManagementService();
            var managmentEmployees = await svc.Get();
            return Ok(managmentEmployees);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateManagementService();
            var manager =await svc.Get(id);
            return Ok(manager);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(ManagementCreate management)
        {
            if (management is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateManagementService();
            var success = await svc.Post(management);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(ManagementEdit management, int id)
        {
            if (id<1|| management.EmployeeID!=id||management is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateManagementService();
            var success = await svc.Put(management, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var svc = CreateManagementService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
