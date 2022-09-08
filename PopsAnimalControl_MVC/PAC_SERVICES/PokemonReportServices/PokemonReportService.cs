using PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.PokemonReport_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.PokemonReportServices
{
    public class PokemonReportService
    {
        private HttpClient _client;
        private PokemonReportRepository _repo;
        public PokemonReportService()
        {
            _client = new HttpClient();
            _repo = new PokemonReportRepository(_client);
        }
        public async Task<List<PokemonReportListItem>> Get(string url, string email)
        {
            var pokemonReports = await _repo.Get(url, email);
            return pokemonReports;
        }
        public async Task<PokemonReportDetails> Get(string url, string email, int id)
        {
            var pokemonReport = await _repo.Get(url, email, id);
            return pokemonReport;
        }
        public async Task<bool> Post(string url, string email,PokemonReportCreate pokemonReport)
        {
            var success = await _repo.Post(url, email, pokemonReport);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, PokemonReportEdit pokemonReport, int id)
        {
            var success = await _repo.Put(url, email, pokemonReport, id);
            if (success)
            {
                return true;
            }
            return false;
        }

    }
}