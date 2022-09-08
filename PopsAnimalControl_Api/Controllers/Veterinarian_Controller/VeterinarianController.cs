using Microsoft.AspNet.Identity;
using PAC.Models.VeterinarianModels;
using PAC.Services.VeterinarianServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Veterinarian_Controller
{
    public class VeterinarianController : ApiController
    {
        private VeterinarianService CreateVeterinarianService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new VeterinarianService(userId);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateVeterinarianService();
            var vets = await svc.Get();
            return Ok(vets);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateVeterinarianService();
            var vet = await svc.Get(id);
            return Ok(vet);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(VeterinarianCreate veterinarian)
        {
            if (veterinarian is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateVeterinarianService();
            var success = await svc.Post(veterinarian);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(VeterinarianEdit veterinarian, int id)
        {
            if (id<1||id!=veterinarian.EmployeeID||veterinarian is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateVeterinarianService();
            var success = await svc.Put(veterinarian, id);
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
            var svc = CreateVeterinarianService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
