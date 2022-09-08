using AutoMapper;
using Microsoft.AspNet.Identity;
using PAC.Data.DogCatchers;
using PAC.Models.DogCatcherModels;
using PAC.Services.DogCatcherServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.DogCatcher_Controller
{
    //Human Resources/ Admin Access
    public class DogCatcherController : ApiController
    {
       
        private DogCatcherService CreateDogCatcherService()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var service = new DogCatcherService(user);
            return service;
        }
        private DogCatcherService CreateDogCatcherService(Guid guid)
        {
            var svc = new DogCatcherService(guid);
            return svc;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var service = CreateDogCatcherService();
            var dogCatchersInRepo =await service.Get();
            //  var dogCatchers = Mapper.Map<IList<DogCatcherListItem>>(dogCatchersInRepo);
            var dogCatchers = dogCatchersInRepo.ToList();
            return Ok(dogCatchers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var service = CreateDogCatcherService();
            var dogCatcherInRepo = await service.Get(id);
            if (dogCatcherInRepo is null)
            {
                return NotFound();
            }
            var dogCatcher = Mapper.Map<DogCatcherDetail>(dogCatcherInRepo);
            return Ok(dogCatcher);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] DogCatcherCreate model)
        {
            var svc = CreateDogCatcherService();
            if (model is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isSuccessful = await svc.Post(model);

            if (isSuccessful)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] DogCatcherEdit model, [FromUri] int id)
        {
            if (id<1 || model.EmployeeID != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var svc = CreateDogCatcherService();
           
            var dogCatcher = Mapper.Map<DogCatcher>(model);
            var isSuccessful = await svc.Put(dogCatcher);

            if (isSuccessful)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var svc = CreateDogCatcherService();
           
            if (id<1)
            {
                return BadRequest();
            }
            
            var isSuccessful = await svc.Delete(id);
            
            if (isSuccessful)
            {
                return Ok();
            }
           
            return InternalServerError();
        }

        [HttpGet]
        [Route("api/DogCatcher/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogCatcherService(guid);
            var dogCatchers = await svc.Get();
            return Ok(dogCatchers);
        }
        [HttpGet]
        [Route("api/DogCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogCatcherService(guid);
            var dogCatcher = await svc.Get(id);
            return Ok(dogCatcher);
        }
        [HttpPost]
        [Route("api/DogCatcher/{email}")]
        public async Task<IHttpActionResult> Post(string email, DogCatcherCreate dogCatcher)
        {
            if (dogCatcher is null || ModelState.IsValid==false)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogCatcherService(guid);
            
            var success = await svc.Post(dogCatcher);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/DogCatcher/{email}/{id}")]
        public async Task<IHttpActionResult>Put(string email,DogCatcherEdit dogCatcher, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogCatcherService(guid);
            var success = await svc.Put(dogCatcher,id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/DogCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email, int id)
        {
            if (id<1)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreateDogCatcherService(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
