using Microsoft.AspNet.Identity;
using PAC.Models.AnimalModels.BreedModels.CatBreeds;
using PAC.Services.BreedServices.CatBreedServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.CatBreed_Controller
{
    public class CatBreedController : ApiController
    {
        private CatBreedService CreateCatBreedService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatBreedService(userID);
            return svc;
        }
        private CatBreedService CreateCatBreedService(Guid guid)
        {
            var svc = new CatBreedService(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateCatBreedService();
            var breeds = await svc.Get();
            return Ok(breeds);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri]int id)
        {
            var svc = CreateCatBreedService();
            var breed = await svc.Get(id);
            return Ok(breed);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CatBreedCreate catBreed)
        {
            if (catBreed is null ||!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatBreedService();
            var success = await svc.Post(catBreed);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] CatBreedEdit catBreed, [FromUri] int id)
        {
            if (id<1||id!=catBreed.Cat_BreedID||catBreed is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatBreedService();
            var success = await svc.Put(catBreed, id);
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
            var svc = CreateCatBreedService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/CatBreed/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatBreedService(guid);
            var breeds = await svc.Get();
            return Ok(breeds);
        }
        [HttpGet]
        [Route("api/CatBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateCatBreedService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var breed = await svc.Get(id);
            return Ok(breed);
        }
        [HttpPost]
        [Route("api/CatBreed/{email}")]
        public async Task<IHttpActionResult> Post(string email, CatBreedCreate catBreed)
        {
            var guid = UtilityMethods.GetGuid(email);
            if (catBreed is null ||!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateCatBreedService(guid);
            var success = await svc.Post(catBreed);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/CatBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, CatBreedEdit catBreed, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            if (id<1||catBreed.Cat_BreedID!=id||catBreed is null)
            {
                return BadRequest();
            }
            var svc = new CatBreedService(guid);
            var success = await svc.Put(catBreed, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/CatBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            if (id<1)
            {
                return BadRequest();
            }
            var svc = CreateCatBreedService(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}
