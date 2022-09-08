using Microsoft.AspNet.Identity;
using PAC.Models.AnimalModels.CatModels;
using PAC.Services.CatServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Cat_Controller
{
    public class CatController : ApiController
    {
        private CatService CreateCatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatService(userId);
            return svc;
        }
        private CatService CreateCatService(Guid guid)
        {
            var svc = new CatService(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateCatService();
            var cats = await svc.Get();
            return Ok(cats);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var svc = CreateCatService();
            var cat = await svc.Get(id);
            return Ok(cat);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CatCreate cat)
        {
            if (cat is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatService();
            var success = await svc.Post(cat);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] CatEdit cat, [FromUri] int id)
        {
            if (id<1||cat.ID!=id||cat is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatService();
            var success = await svc.Put(cat, id);
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
            var svc = CreateCatService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/Cat/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatService(guid);
            var cats = await svc.Get();
            return Ok(cats);
        }
        [HttpGet]
        [Route("api/Cat/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var cat = await svc.Get(id);
            return Ok(cat);
        }
        [HttpPost]
        [Route("api/Cat/{email}/{id}")]
        public async Task<IHttpActionResult> Post(string email,CatCreate cat)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatService(guid);
            if (cat is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await svc.Post(cat);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/Cat/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, CatEdit cat, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatService(guid);
            if (id<1||id!=cat.ID||cat is null)
            {
                return BadRequest();
            }
            var success = await svc.Put(cat, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Cat/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}
