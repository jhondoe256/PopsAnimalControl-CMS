using PopsAnimalControl_MVC.Models.ViewModels.DogViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Dog_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.DogServices
{
    public class DogService
    {
        private HttpClient _client;
        private DogRepository _repo;
        public DogService()
        {
            _client = new HttpClient();
            _repo = new DogRepository(_client);
        }
        public async Task<List<DogListItem>> Get(string url, string email)
        {
            var dogs = await _repo.Get(url, email);
            return dogs;
        }
        public async Task<DogDetail> Get(string url, string email, int id)
        {
            var dog = await _repo.Get(url, email, id);
            return dog;
        }
        public async Task<bool> Post(string url, string email,DogCreate dogCreate)
        {
            var success = await _repo.Post(url, email,dogCreate);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, DogEdit dogEdit, int id)
        {
            var success = await _repo.Put(url, email, dogEdit, id);
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