using PopsAnimalControl_MVC.Models.ViewModels.DogCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogCatcher_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.DogCatcherServices
{
    public class DogCatcherService
    {
        private HttpClient _client;
        private DogCatcherRepo _repo;
        public DogCatcherService()
        {
            _client = new HttpClient();
            _repo = new DogCatcherRepo(_client);
        }
        public async Task<List<DogCatcherListItem>> Get(string url, string email)
        {
            var dogCatchers = await _repo.Get(url, email);
            return dogCatchers;
        }
        public async Task<DogCatcherDetails> Get(string url, string email, int id)
        {
            var dogCatcher = await _repo.Get(url, email, id);
            return dogCatcher;
        }
        public async Task<bool> Post(string url, string email, DogCatcherCreate dogCatcher)
        {
            var success = await _repo.Post(url, email, dogCatcher);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, DogCatcherEdit dogCatcher, int id)
        {
            var success = await _repo.Put(url, email, dogCatcher, id);
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