using PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogReport_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.DogReportServices
{
    public class DogReportService
    {
        private HttpClient _client;
        private DogReportRepository _repo;
        public DogReportService()
        {
            _client = new HttpClient();
            _repo = new DogReportRepository(_client);
        }
        public async Task<List<DogReportListItem>> Get(string url, string email)
        {
            var dogs = await _repo.Get(url, email);
            return dogs;
        }
        public async Task<DogReportDetails> Get(string url, string email, int id)
        {
            var dog = await _repo.Get(url, email, id);
            return dog;
        }
        public async Task<bool> Post(string url, string email, DogReportCreate dogReport)
        {
            var success = await _repo.Post(url, email, dogReport);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, DogReportEdit dogReport, int id)
        {
            var success = await _repo.Put(url, email, dogReport, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        //public async Task<bool> Delete(string url, string email, int id)
        //{
        //    var success = await _repo.Delete(url,email,id);
        //    if (success)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}