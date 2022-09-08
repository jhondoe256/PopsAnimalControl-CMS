using Microsoft.AspNet.Identity;
using PAC.Models.DogModels;
using PAC.Services.DogServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Dog_Controller
{

    public class DogController : ApiController
    {
        private DogService CreateDogService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogService(user);
            return svc;
        }
        private DogService CreateDogService(Guid guid)
        {
            var svc = new DogService(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateDogService();
            var dogs = await svc.Get();
            return Ok(dogs);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateDogService();
            var dog = await svc.Get(id);
            return Ok(dog);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(DogCreate dog)
        {
            if (dog is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDogService();
            var success = await svc.Post(dog);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(DogEdit dog, int id)
        {
            if (id<1||id!=dog.ID||dog is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDogService();
            var success = await svc.Put(dog, id);
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
            var svc = CreateDogService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/Dog/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogService(guid);
            var dogs = await svc.Get();
            return Ok(dogs);
        }
        [HttpGet]
        [Route("api/Dog/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var dog = await svc.Get(id);
            return Ok(dog);
        }
        [HttpPost]
        [Route("api/Dog/{email}")]
        public async Task<IHttpActionResult> Post(string email,DogCreate dogCreate)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogService(guid);
            if (dogCreate is null || ModelState.IsValid==false)
            {
                return BadRequest();
            }
            var success = await svc.Post(dogCreate);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/Dog/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, DogEdit dogEdit, int id)
        {

            if (dogEdit.ID!=id||id<1||dogEdit is null)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogService(guid);
            var success = await svc.Put(dogEdit, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Dog/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogService(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
