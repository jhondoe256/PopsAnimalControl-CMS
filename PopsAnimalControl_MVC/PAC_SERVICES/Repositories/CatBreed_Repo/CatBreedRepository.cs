using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.CatBreedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.CatBreed_Repo
{
    public class CatBreedRepository
    {
        private HttpClient _client;
        public CatBreedRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<CatBreedListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CatBreedListItem>>(content);
            }
            return null;
        }
        public async Task<CatBreedDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatBreedDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, CatBreedCreate catBreed)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (catBreed is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(catBreed), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, CatBreedEdit catBreed, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (catBreed is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(catBreed), Encoding.UTF8, "application/json");
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