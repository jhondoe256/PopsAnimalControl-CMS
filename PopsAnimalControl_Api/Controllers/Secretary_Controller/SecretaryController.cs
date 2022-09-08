using Microsoft.AspNet.Identity;
using PAC.Models.SecretaryModels;
using PAC.Services.SecretaryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Secretary_Controller
{
    public class SecretaryController : ApiController
    {
        private SecretaryService CreateSecretaryService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new SecretaryService(user);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateSecretaryService();
            var secretaries = await svc.Get();
            return Ok(secretaries);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateSecretaryService();
            var sevretary = await svc.Get(id);
            return Ok(sevretary);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(SecretaryCreate secretaryCreate)
        {
            if (secretaryCreate is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateSecretaryService();
            var success = await svc.Post(secretaryCreate);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(SecretaryEdit secretary, int id)
        {
            if (id<1||id!=secretary.EmployeeID||secretary is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateSecretaryService();
            var success = await svc.Put(secretary, id);
            if (success)
            {
                return Ok();
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
            var svc = CreateSecretaryService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
