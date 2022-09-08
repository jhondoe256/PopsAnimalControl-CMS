using Microsoft.AspNet.Identity;
using PAC.Models.ReportModels.PokemonReportModels;
using PAC.Services.ReportServices.Pokemon_Report_Services;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Reports_Controller.PokemonReport_Controller
{
    public class PokemonReportController : ApiController
    {
        private PokemonReportService CreatePRS()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonReportService(user);
            return svc;
        }
        private PokemonReportService CreatePRS(Guid guid)
        {
            var svc = new PokemonReportService(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreatePRS();
            var reports = await svc.Get();
            return Ok(reports);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreatePRS();
            var report = await svc.Get(id);
            return Ok(report);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(PokemonReportCreate pokemonReport)
        {
            if (pokemonReport is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePRS();
            var success = await svc.Post(pokemonReport);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(PokemonReportEdit pokemonReportEdit, int id)
        {
            if (id<1 || pokemonReportEdit.ReportID!=id||pokemonReportEdit is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePRS();
            var success = await svc.Put(pokemonReportEdit, id);
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
            var svc = CreatePRS();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/PokemonReport/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePRS(guid);
            var reports = await svc.Get();
            return Ok(reports);
        }
        [HttpGet]
        [Route("api/PokemonReport/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePRS(guid);
            var report = await svc.Get(id);
            return Ok(report);
        }
        [HttpPost]
        [Route("api/PokemonReport/{email}")]
        public async Task<IHttpActionResult> Post(string email, PokemonReportCreate pokemonReport)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePRS(guid);
            var success = await svc.Post(pokemonReport);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/PokemonReport/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, PokemonReportEdit pokemonReport,int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePRS(guid);
            var success = await svc.Put(pokemonReport,id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/PokemonReport/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email,int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePRS(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
