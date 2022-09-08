using Microsoft.AspNet.Identity;
using PAC.Models.PokemonModels;
using PAC.Services.PokemonServices;
using PAC.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.Pokemon_Controller
{
    public class PokemonController : ApiController
    {
        private PokemonService CreatePokemonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonService(userId);
            return svc;
        }
        private PokemonService CreatePokemonService(Guid guid)
        {
            var svc = new PokemonService(guid);
            return svc;
        }
        [HttpPost]
        [Route("api/PokemonCreate/")]
        public async Task<IHttpActionResult> Post([FromBody] PokemonCreate pokemon)
        {
            if (pokemon is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePokemonService();
            var success = await svc.Post(pokemon);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreatePokemonService();
            var pokemon_s = await svc.Get();
            return Ok(pokemon_s);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var svc = CreatePokemonService();
            var pokemon = await svc.Get(id);
            return Ok(pokemon);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] PokemonEdit pokemon, [FromUri] int id)
        {
            if (id < 1 || id != pokemon.PokeID || pokemon is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreatePokemonService();
            var success = await svc.Put(pokemon, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var svc = CreatePokemonService();
            var success = await svc.Delete(id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpGet]
        [Route("api/Pokemon/{email}")]
        public async Task<IHttpActionResult> Get(string Email)
        {
            var guid = UtilityMethods.GetGuid(Email);
            var svc = CreatePokemonService(guid);
            var pokeGrp = await svc.Get();
            return Ok(pokeGrp);
        }
        [HttpGet]
        [Route("api/Pokemon/{email}/{id}")]
        public async Task<IHttpActionResult> Get(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePokemonService(guid);
            var pokemon = await svc.Get(id);
            return Ok(pokemon);
        }
        [HttpPost]
        [Route("api/Pokemon/{email}")]
        public async Task<IHttpActionResult> Post(string email,PokemonCreate pokemonCreate)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePokemonService(guid);
            if (pokemonCreate is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var success = await svc.Post(pokemonCreate);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpPut]
        [Route("api/Pokemon/{email}/{id}")]
        public async Task<IHttpActionResult> Put(string email, PokemonEdit pokemonEdit, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = new PokemonService(guid);
            if (id<1||id!=pokemonEdit.PokeID||pokemonEdit is null)
            {
                return BadRequest();
            }
            var success = await svc.Put(pokemonEdit, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }
        [HttpDelete]
        [Route("api/Pokemon/{email}/{id}")]
        public async Task<IHttpActionResult>Delete(string email, int id)
        {
            var guid = UtilityMethods.GetGuid(email);
            var svc = CreatePokemonService(guid);
            if (id<1)
            {
                return BadRequest();
            }
            var sucess = await svc.Delete(id);
            if (sucess)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}