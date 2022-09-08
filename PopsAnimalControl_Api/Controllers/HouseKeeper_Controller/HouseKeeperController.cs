using Microsoft.AspNet.Identity;
using PAC.Models.HouseKeeperModels;
using PAC.Services.HouseKeepingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.HouseKeeper_Controller
{
    public class HouseKeeperController : ApiController
    {
        private HouseKeepingService CreateHouseKeepingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new HouseKeepingService(userId);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateHouseKeepingService();
            var houseKeepers = await svc.Get();
            return Ok(houseKeepers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateHouseKeepingService();
            var houseKeeper = await svc.Get(id);
            return Ok(houseKeeper);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(HouseKeeperCreate houseKeeper)
        {
            if (houseKeeper is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateHouseKeepingService();
            var success = await svc.Post(houseKeeper);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(HouseKeeperEdit houseKeeper, int id)
        {
            if (id<1 || id!=houseKeeper.EmployeeID||houseKeeper is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateHouseKeepingService();
            var success = await svc.Put(houseKeeper, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Detlet(int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateHouseKeepingService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
