using Microsoft.AspNet.Identity;
using PAC.Models.HiredEmployeeModels;
using PAC.Services.HiredEmployeeServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Human_ResourcesController.Human_ResourcesHub
{
    //HUMAN RESOURCES CAN ONLY USE THIS (USER ROLE)
    //[Authorize]
    public class HumanResourcesHUBController : ApiController
    {
        private HumanResourceHub_Service CreateHumanResoursesHubService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var svc = new HumanResourceHub_Service();
            var svc = new HumanResourceHub_Service();
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateHumanResoursesHubService();
            var applicants = await svc.GetApplicantsAsync();
            return Ok(applicants);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateHumanResoursesHubService();
            var applicant = await svc.GetApplicantDetailAsync(id);
            if (applicant is null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] AddEmployeeToDepartment employeeInfo)
        {
            if (employeeInfo is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateHumanResoursesHubService();
            var success = await svc.AssignApplicantToDepartment(employeeInfo);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/HumanResourcesHUB/Update/{positionID}")]
        public async Task<IHttpActionResult> Put([FromBody] AssignEmployeeToDifferentDepartment employeeInfo, [FromUri] int positionID)
        {
            if (employeeInfo is null || positionID < 1)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var svc = CreateHumanResoursesHubService();
            var success = await svc.AssignEmployeeToDifferentDepartment(employeeInfo, positionID);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/HumanResourcesHUB/DogCatcherApplicants/")]
        public async Task<IHttpActionResult> GetDogCatcherApplicants()
        {
            var svc = CreateHumanResoursesHubService();
            var applicants = await svc.GetDogCatcherApplicants();
            return Ok(applicants);
        }

        [HttpGet]
        [Route("api/HumanResourcesHUB/CatCatcherApplicants/")]
        public async Task<IHttpActionResult> GetCatCatcherApplicants()
        {
            var svc = CreateHumanResoursesHubService();
            var applicants = await svc.GetCatCatcherApplicants();
            return Ok(applicants);
        }

        [HttpGet]
        [Route("api/HumanResourcesHUB/PokemonCatcherApplicants/")]
        public async Task<IHttpActionResult> GetPokemonCatcherApplicants()
        {
            var svc = CreateHumanResoursesHubService();
            var applicants = await svc.GetPokemonCatcherApplicants();
            return Ok(applicants);
        }
        [HttpGet]
        [Route("api/HumanResourcesHUB/HumanResourcesApplicants/")]
        public async Task<IHttpActionResult> GetHumanResourcesApplicants()
        {
            var svc = CreateHumanResoursesHubService();
            var applicants = await svc.GetHumanResourcesApplicants();
            return Ok(applicants);
        }

    }
}
