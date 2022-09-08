using PopsAnimalControl_MVC.Models.ViewModels.PokemonCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.PokemonCatcher_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.PokemonCatcherServices
{
   
   
    public class PokemonCatcherService
    {
        private readonly HttpClient _client;
        private readonly PokemonCatcherRepository _repo;
        public PokemonCatcherService()
        {
            _client = new HttpClient();
            _repo = new PokemonCatcherRepository(_client);
        }

        public async Task<List<PokemonCatcherListItem>> Get(string url, string email)
        {
            var pokeCatchers = await _repo.Get(url, email);
            return pokeCatchers;
        }
        public async Task<PokemonCatcherDetail> Get(string url, string email, int id)
        {
            var pokeCatcher = await _repo.Get(url, email, id);
            return pokeCatcher;
        }
        public async Task<bool> Post(string url, string email, PokemonCatcherCreate pokemonCatcher)
        {
            var successs = await _repo.Post(url, email, pokemonCatcher);
            if (successs)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, PokemonCatcherEdit pokemonCatcher, int id)
        {
            var success = await _repo.Put(url, email, pokemonCatcher, id);
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