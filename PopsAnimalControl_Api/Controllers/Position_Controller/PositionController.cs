using Microsoft.AspNet.Identity;
using PAC.Models.PositionModels;
using PAC.Services.PositionServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Position_Controller
{

    public class PositionController : ApiController
    {
        private PositionService CreatePositionService(Guid guid)
        {
            var svc = new PositionService(guid);
            return svc;
        }
        private PositionService CreatePositionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new PositionService(userId);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreatePositionService();
            var positions = await svc.GetPositionsAsync();
            return Ok(positions);
        }
        [HttpGet]
        [Route("api/Position/Get/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreatePositionService();
            if (id < 1)
            {
                return BadRequest();
            }
            var position = await svc.GetPositionDetailAsync(id);
            if (position is null)
            {
                return NotFound();
            }
            return Ok(position);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(PositionCreate model)
        {
            if (model is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePositionService();
            var success = await svc.CreatePositionAsync(model);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/Position/Put/{id}")]
        public async Task<IHttpActionResult> Put(PositionEdit model, int id)
        {
            if (model.PositionID != id || id < 1 || model is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePositionService();
            var success = await svc.UpdatePosition(model, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var svc = CreatePositionService();
            var success = await svc.DeletePosition(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/Position/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePositionService(guid);
            var positions = await svc.GetPositionsAsync();
            return Ok(positions);
        }
        [HttpGet]
        [Route("api/Position/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePositionService(guid);
            var positions = await svc.GetPositionDetailAsync(id);
            return Ok(positions);
        }
        [HttpPost]
        [Route("api/Position/{email}/")]
        public async Task<IHttpActionResult> Post(string email, PositionCreate position)
        {
            if (position is null || ModelState.IsValid==false)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePositionService(guid);
            var success = await svc.CreatePositionAsync(position);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/Position/Update/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, PositionEdit position, int id)
        {
            if (id < 1 || id != position.PositionID || position is null)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePositionService(guid);
            var success = await svc.UpdatePosition(position,id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Position/Delete/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePositionService(guid);
            var success = await svc.DeletePosition(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
