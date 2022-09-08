using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonCatcherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.PokemonCatcher_Repo
{
    public class PokemonCatcherRepository
    {
        private readonly HttpClient _client;
        public PokemonCatcherRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<PokemonCatcherListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PokemonCatcherListItem>>(content);
            }
            return null;
        }
        public async Task<PokemonCatcherDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PokemonCatcherDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email,PokemonCatcherCreate pokemonCatcher)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (pokemonCatcher is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemonCatcher), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL , string email, PokemonCatcherEdit pokemonCatcher, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemonCatcher),Encoding.UTF8,"application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}