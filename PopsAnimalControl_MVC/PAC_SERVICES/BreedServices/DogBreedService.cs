using PopsAnimalControl_MVC.Models.ViewModels.BreedViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogBreed_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.BreedServices
{
    public class DogBreedService
    {
        private HttpClient _client;
        private DogBreedRepository _repo;
        public DogBreedService()
        {
            _client = new HttpClient();
            _repo = new DogBreedRepository(_client);
        }
        public async Task<List<DogBreedListItem>> Get(string url, string email)
        {
            var breeds = await _repo.Get(url, email);
            return breeds;
        }
        public async Task<DogBreedDetail> Get(string url, string email, int id)
        {
            var breed = await _repo.Get(url, email, id);
            return breed;
        }
        public async Task<bool> Post(string url, string email,DogBreedCreate dogBreed)
        {
            var success = await _repo.Post(url, email, dogBreed);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, DogBreedEdit dogBreed, int id)
        {
            var success = await _repo.Put(url, email, dogBreed, id);
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