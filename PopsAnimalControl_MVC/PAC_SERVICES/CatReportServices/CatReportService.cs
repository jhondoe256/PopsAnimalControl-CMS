using PopsAnimalControl_MVC.Models.ViewModels.CatReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.CatReport_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.CatReportServices
{
    public class CatReportService
    {
        private HttpClient _client;
        private CatReportRepository _repo;
        public CatReportService()
        {
            _client = new HttpClient();
            _repo = new CatReportRepository(_client);
        }
        public async Task<List<CatReportListItem>> Get(string url, string email)
        {
            var reports = await _repo.Get(url, email);
            return reports;
        }
        public async Task<CatReportDetail> Get(string url, string email, int id)
        {
            var report = await _repo.Get(url, email, id);
            return report;
        }
        public async Task<bool> Post(string url, string email, CatReportCreate catReport)
        {
            var success = await _repo.Post(url, email, catReport);
            if (success)
            {
                return true;    
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, CatReportEdit catReport, int id)
        {
            var success = await _repo.Put(url, email, catReport, id);
            if (success)
            {
                return true;
            }
            return false;
        }
    }
}