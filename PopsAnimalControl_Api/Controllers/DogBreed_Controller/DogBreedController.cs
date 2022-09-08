using Microsoft.AspNet.Identity;
using PAC.Models.AnimalModels.BreedModels.DogBreeds;
using PAC.Services.BreedServices.DogBreedServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.DogBreed_Controller
{
    public class DogBreedController : ApiController
    {
        private DogBreedService CreateDogBreedService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogBreedService(user);
            return svc;
        }
        private DogBreedService CreateDogBreedService(Guid guid)
        {
            var svc = new DogBreedService(guid);
            return svc;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(DogBreedCreate dogBreed)
        {
            if (dogBreed is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDogBreedService();
            var success = await svc.Post(dogBreed);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(DogBreedEdit dogBreed, int id)
        {
            if (id<1|| dogBreed.BreedID!=id||dogBreed is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateDogBreedService();
            var success = await svc.Put(dogBreed, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateDogBreedService();
            var breeds = await svc.Get();
            return Ok(breeds);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreateDogBreedService();
            var dog = await svc.Get(id);
            return Ok(dog);
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var svc = CreateDogBreedService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/DogBreed/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogBreedService(guid);
            var breeds = await svc.Get();
            return Ok(breeds);
        }
        [HttpGet]
        [Route("api/DogBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogBreedService(guid);
            var breed = await svc.Get(id);
            return Ok(breed);
        }
        [HttpPost]
        [Route("api/DogBreed/{email}/")]
        public async Task<IHttpActionResult> Post(string email, DogBreedCreate dogBreed)
        {
            if (dogBreed is null || ModelState.IsValid==false)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogBreedService(guid);
            var success = await svc.Post(dogBreed);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/DogBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, DogBreedEdit dogBreed, int id)
        {
            if (id<1 || dogBreed.BreedID!=id || dogBreed is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogBreedService(guid);
            var success = await svc.Put(dogBreed, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/DogBreed/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email,int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogBreedService(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
