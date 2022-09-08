using Microsoft.AspNet.Identity;
using PAC.Models.ApplicantModels;
using PAC.Services.ApplicantServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Applicant_Controller
{
    
    public class ApplicantController : ApiController
    {
        private ApplicantService CreateApplicantService()
        {
            //var userID = Guid.Parse(User.Identity.GetUserId());
           
           // var svc = new ApplicantService(userID);
            var svc = new ApplicantService();
            return svc;
        }
       
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ApplicantCreate model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateApplicantService();
            var success = await svc.CreateApplicantAsync(model);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] ApplicantEdit model, [FromUri] int id)
        {
            if (id<1 ||model is null || id!=model.ID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateApplicantService();
            var success = await svc.UpdateApplicantDataAsync(model, id);
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
            var svc = CreateApplicantService();
            var success = await svc.DeleteApplicantDataAsync(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetApplicant([FromUri] int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateApplicantService();
            var applicant = await svc.GetApplicantByID(id);
            if (applicant is null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }
        [HttpGet]
        [Route("api/Applicant/Info/{email}")]
        public async Task<IHttpActionResult> GetApplicant([FromUri] string email)
        {
            if (email is null)
            {
                return BadRequest();
            }
            var svc = CreateApplicantService();
            var applicant = await svc.GetApplicantByEmail(email);
            if (applicant is null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }
        [HttpPut]
        [Route("api/Applicant/Update/{email}")]
        public async Task<IHttpActionResult> Put([FromBody] ApplicantEdit model, [FromUri] string email)
        {
            if (email is null || model is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateApplicantService();
            var success = await svc.UpdateApplicantDataViaEmailAsync(model, email);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
