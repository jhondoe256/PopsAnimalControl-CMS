using PopsAnimalControl_MVC.Models.ViewModels.CatCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.CatCatcher_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.CatCatcherServices
{
    public class CatCatcherService
    {
        private HttpClient _client;
        private CatCatcherRepository _repo;
        public CatCatcherService()
        {
            _client = new HttpClient();
            _repo = new CatCatcherRepository(_client);
        }
        public async Task<List<CatCatcherListItem>> Get(string url, string email)
        {
            var CatCatchers = await _repo.Get(url, email);
            return CatCatchers;
        }
        public async Task<CatCatcherDetail> Get(string url, string email, int id)
        {
            var CatCatcher = await _repo.Get(url, email, id);
            return CatCatcher;
        }
        public async Task<bool> Post(string url, string email, CatCatcherCreate catCatcher)
        {
            var success = await _repo.Post(url, email, catCatcher);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, CatCatcherEdit catCatcher, int id)
        {
            var success = await _repo.Put(url, email, catCatcher, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string url, string email,int id)
        {
            var success = await _repo.Delete(url, email,id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}