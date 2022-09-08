using Microsoft.AspNet.Identity;
using PAC.Models.VetTechModels;
using PAC.Services.VetTechServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.VetTech_Controller
{
    public class VetTechController : ApiController
    {
        private VetTechService CreateVetTechService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new VetTechService(userId);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateVetTechService();
            var techs = await svc.Get();
            return Ok(techs);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateVetTechService();
            var vTech = await svc.Get(id);
            return Ok(vTech);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(VetTechCreate vetTech)
        {
            if (vetTech is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateVetTechService();
            var success = await svc.Post(vetTech);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(VetTechEdit vetTech, int id)
        {
            if (id<1 || vetTech.EmployeeID!=id||vetTech is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateVetTechService();
            var success = await svc.Put(vetTech, id);
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
            var svc = CreateVetTechService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
