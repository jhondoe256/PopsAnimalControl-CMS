using Microsoft.AspNet.Identity;
using PAC.Models.HumanResourceModels;
using PAC.Services.HumanResourcesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Human_ResourcesController
{
    public class HumanResourceEmployeeController : ApiController
    {
        private HumanResourceService CreateHumanResourceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            //var svc = new HumanResourceService(userId);
            var svc = new HumanResourceService();
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateHumanResourceService();
            var hREs = await svc.Get();
            return Ok(hREs);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateHumanResourceService();
            var employee = await svc.Get(id);
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(HumanResourceCreate humanResource)
        {
            if (humanResource is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateHumanResourceService();
            var success = await svc.Post(humanResource);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(HumanResourceEdit humanResource, int id)
        {
            if (id < 1 || id != humanResource.EmployeeID || humanResource is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateHumanResourceService();
            var success = await svc.Put(humanResource, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var svc = CreateHumanResourceService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
