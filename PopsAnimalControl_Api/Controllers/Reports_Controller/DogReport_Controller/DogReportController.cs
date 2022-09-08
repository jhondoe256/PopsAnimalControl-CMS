using Microsoft.AspNet.Identity;
using PAC.Models.ReportModels.DogReportModels;
using PAC.Services.ReportServices.Dog_Report_Services;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Reports_Controller.DogReport_Controller
{
    public class DogReportController : ApiController
    {
        private DogCatcher_Report_Service CreateDCR_Service()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogCatcher_Report_Service(userId);
            return svc;
        }
        private DogCatcher_Report_Service CreateDCR_Service(Guid guid)
        {
            var svc = new DogCatcher_Report_Service(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateDCR_Service();
            var reports = await svc.Get();
            return Ok(reports);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]int id)
        {
            var svc = CreateDCR_Service();
            var report = await svc.Get(id);
            return Ok(report);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]DogReportCreate dogReport)
        {
            if (dogReport is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDCR_Service();
            if (await svc.Post(dogReport))
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]DogReportEdit dogReport,[FromUri] int id)
        {
            if (id<1 ||id!=dogReport.ReportID|| dogReport is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDCR_Service();
            var success = await svc.Put(dogReport, id);
            if (success)
            {
                return Ok();
            }
           
            return InternalServerError();
        }
        //[HttpDelete]
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    if (id<1)
        //    {
        //        return BadRequest();
        //    }
        //    var svc = CreateDCR_Service();
        //    if (await svc.Delete(id))
        //    {
        //        return Ok();
        //    }
        //    return InternalServerError();
        //}

        [HttpGet]
        [Route("api/DogReport/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDCR_Service(guid);
            var dogs = await svc.Get();
            return Ok(dogs);
        }
        [HttpGet]
        [Route("api/DogReport/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDCR_Service(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var dog = await svc.Get(id);
            return Ok(dog);
        }
        [HttpPost]
        [Route("api/DogReport/{email}")]
        public async Task<IHttpActionResult> Post(string email, DogReportCreate dogReport)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDCR_Service(guid);
            if (dogReport is null || ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var success = await svc.Post(dogReport);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/DogReport/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, DogReportEdit dogReport, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDCR_Service(guid);
            if (id<1||dogReport.ID!=id||dogReport is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await svc.Put(dogReport, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        //[HttpDelete]
        //[Route("api/DogReport/{email}/{id}")]
        //public async Task<IHttpActionResult> Delete(string email, int id)
        //{
        //    var guid = UtilityMethods.GetGuid(email);
        //    var svc = CreateDCR_Service(guid);
        //    var success = await svc.de
        //}
    }
}
