using PopsAnimalControl_MVC.Models.ViewModels.CatViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Cat_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.CatServices
{
    public class CatService
    {
        private HttpClient _client;
        private CatRepository _repo;
        public CatService()
        {
            _client = new HttpClient();
            _repo = new CatRepository(_client);
        }
        public async Task<List<CatListItem>> Get(string url, string email)
        {
            var cats = await _repo.Get(url, email);
            return cats;
        }
        public async Task<CatDetail> Get(string url, string email, int id)
        {
            var cat = await _repo.Get(url, email, id);
            return cat;
        }
        public async Task<bool> Post(string url, string email, CatCreate cat)
        {
            var success = await _repo.Post(url, email, cat);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, CatEdit cat, int id)
        {
            var success = await _repo.Put(url, email, cat, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string url, string email, int id)
        {
            var success=await _repo.Delete(url, email, id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}