using Microsoft.AspNet.Identity;
using PAC.Models.PokemonCatcherModels;
using PAC.Services.PokemonCatcherServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.PokemonCatcher_Controller
{
    
    public class PokemonCatcherController : ApiController
    {
        private PokemonCatcherService CreatePCS()
        {
            var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonCatcherService(user);
            return svc;
        }
        private PokemonCatcherService CreatePCS(Guid guid)
        {
            var svc = new PokemonCatcherService(guid);
            return svc;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreatePCS();
            var pokeCatchers = await svc.Get();
            return Ok(pokeCatchers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var svc = CreatePCS();
            var pokeCatcher = await svc.Get(id);
            return Ok(pokeCatcher);
        }
        [HttpPost]
        public async Task<IHttpActionResult> Post(PokemonCatcherCreate pokemonCatcher)
        {
            if (pokemonCatcher is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePCS();
            var success = await svc.Post(pokemonCatcher);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put(PokemonCatcherEdit pokemonCatcher, int id)
        {
            if (id<1 || pokemonCatcher.EmployeeID!=id || pokemonCatcher is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var svc = CreatePCS();
            var success = await svc.Put(pokemonCatcher, id);
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
            var svc = CreatePCS();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/PokemonCatcher/{email}")]
        public async Task<IHttpActionResult> Get(string email)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePCS(guid);
            var pCatchers = await svc.Get();
            return Ok(pCatchers);
        }
        [HttpGet]
        [Route("api/PokemonCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePCS(guid);
            var pCatcher = await svc.Get(id);
            return Ok(pCatcher);
        }
        [HttpPost]
        [Route("api/PokemonCatcher/{email}")]
        public async Task<IHttpActionResult> Post(string email,PokemonCatcherCreate pokemonCatcher)
        {
            if (pokemonCatcher is null || ModelState.IsValid == false)
            {
                return BadRequest();
            }
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePCS(guid);
            var success = await svc.Post(pokemonCatcher);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/PokemonCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, PokemonCatcherEdit pokemonCatcher, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePCS(guid);
            var success = await svc.Put(pokemonCatcher,id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/PokemonCatcher/{email}/{id}")]
        public async Task<IHttpActionResult> Delete(string email,int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePCS(guid);
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
