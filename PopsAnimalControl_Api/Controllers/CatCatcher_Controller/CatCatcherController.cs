using Microsoft.AspNet.Identity;
using PAC.Models.CatcherModels;
using PAC.Services.CatCatcherServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.CatCatcher_Controller
{
    public class CatCatcherController : ApiController
    {
        private CatCatcherService CreateCatCatcherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatCatcherService(userId);
            return svc;
        }

        private CatCatcherService CreateCatCatcherService(Guid guid)
        {
            var svc = new CatCatcherService(guid);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateCatCatcherService();
            var catCatchers = await svc.Get();
            return Ok(catCatchers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var svc = CreateCatCatcherService();
            var catCatcher = await svc.Get(id);
            return Ok(catCatcher);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CatCatcherCreate catCatcher)
        {
            if (catCatcher is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatCatcherService();
            var success = await svc.Post(catCatcher);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] CatCatcherEdit catCatcher)
        {
            if (id<1 ||id!=catCatcher.EmployeeID|| catCatcher is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatCatcherService();
            var success = await svc.Put(catCatcher, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateCatCatcherService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/CatCatcher/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherService(guid);
            var CatCatchers = await svc.Get();
            return Ok(CatCatchers.ToList());
        }
        [HttpGet]
        [Route("api/CatCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var catCatcher = await svc.Get(id);
            return Ok(catCatcher);
        }
        [HttpPost]
        [Route("api/CatCatcher/{email}")]
        public async Task<IHttpActionResult> Post(string email, CatCatcherCreate catCatcher)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherService(guid);
            var success = await svc.Post(catCatcher);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/CatCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, CatCatcherEdit catCatcher, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherService(guid);
            var success = await svc.Put(catCatcher, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/CatCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherService(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
