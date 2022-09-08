using PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Pokemon_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.PokemonServices
{
    public class PokemonService
    {
        private HttpClient _client;
        private PokemonRepository _repo;
        public PokemonService()
        {
            _client = new HttpClient();
            _repo = new PokemonRepository(_client);
        }
        public async Task<List<PokemonListItem>> Get(string url, string email)
        {
            var pokemonS = await _repo.Get(url, email);
            return pokemonS;
        }
        public async Task<PokemonDetail> Get(string url, string email, int id)
        {
            var pokemon = await _repo.Get(url, email, id);
            return pokemon;
        }
        public async Task<bool> Post(string url, string email, PokemonCreate pokemon)
        {
            var success = await _repo.Post(url, email, pokemon);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, PokemonEdit pokemon, int id)
        {
            var success = await _repo.Put(url, email, pokemon, id);
            if (success)
            {
                return true;
            }
            return false;   
        }
        public async Task<bool> Delete(string url, string email, int id)
        {
            var success = await _repo.Delete(url, email, id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}