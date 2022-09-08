using PopsAnimalControl_MVC.Models.ViewModels.CatBreedViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.CatBreed_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.CatBreedServices
{
    public class CatBreedService
    {
        private HttpClient _client;
        private CatBreedRepository _catRepo;

        public CatBreedService()
        {
            _client = new HttpClient();
            _catRepo = new CatBreedRepository(_client);
        }
        public async Task<List<CatBreedListItem>> Get(string url, string email)
        {
            var breeds = await _catRepo.Get(url, email);
            return breeds;
        }
        public async Task<CatBreedDetail> Get(string url, string email, int id)
        {
            var breed = await _catRepo.Get(url, email, id);
            return breed;
        }
        public async Task<bool> Post(string url, string email,CatBreedCreate catBreed)
        {
            var success = await _catRepo.Post(url, email,catBreed);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, CatBreedEdit catBreed, int id)
        {
            var success = await _catRepo.Put(url, email, catBreed, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string url, string email, int id)
        {
            var success = await _catRepo.Delete(url, email, id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}