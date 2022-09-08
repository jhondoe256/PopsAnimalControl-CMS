using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.PokemonReport_Repo
{
    public class PokemonReportRepository
    {
        private HttpClient _client;
        public PokemonReportRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<PokemonReportListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PokemonReportListItem>>(content);
            }
            return null;
        }
        public async Task<PokemonReportDetails> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PokemonReportDetails>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, PokemonReportCreate pokemonReportCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (pokemonReportCreate is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemonReportCreate), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, PokemonReportEdit pokemonReport, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (pokemonReport is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemonReport), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        

    }
}