using Microsoft.AspNet.Identity;
using PAC.Models.ReportModels.CatReportModels;
using PAC.Services.ReportServices.Cat_Report_Services;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Reports_Controller.CatReport_Controller
{
    public class CatCatcherReoprtController : ApiController
    {
        private CatCatcher_Report_Service CreateCatCatcherReportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatCatcher_Report_Service(userId);
            return svc;
        }
        private CatCatcher_Report_Service CreateCatCatcherReportService(Guid guid)
        {
            var svc = new CatCatcher_Report_Service(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateCatCatcherReportService();
            var reports = await svc.Get();
            return Ok(reports);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var svc = CreateCatCatcherReportService();
            var report = await svc.Get(id);
            return Ok(report);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CatReportCreate catReport)
        {
            if (catReport is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatCatcherReportService();
            var success = await svc.Post(catReport);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] CatReportEdit catReport, [FromUri] int id)
        {
            if (id < 1 || catReport.ID != id || catReport is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatCatcherReportService();
            var success = await svc.Put(catReport, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/CatCatcherReport/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherReportService(guid);
            var reports = await svc.Get();
            return Ok(reports);
        }
        [HttpGet]
        [Route("api/CatCatcherReport/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherReportService(guid);
            var report = await svc.Get(id);
            return Ok(report);
        }
        [HttpPost]
        [Route("api/CatCatcherReport/{email}")]
        public async Task<IHttpActionResult> Post(string email, CatReportCreate catReport)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherReportService(guid);
            if (catReport is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await svc.Post(catReport);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/CatCatcherReport/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, CatReportEdit catReport, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatCatcherReportService(guid);
            if (id<1||catReport.ID!=id||catReport is null)
            {
                return BadRequest();
            }
            var success = await svc.Put(catReport, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
