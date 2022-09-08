using Newtonsoft.Json;
using PopsAnimalControl_Console_UI.PAC_SERVICES.DogCatcherServices;
using PopsAnimalControl_Console_UI.ViewModels.DogCatcherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.Repositories.DogCatcherRepo
{
    public class DogCatcherRepository
    {
        private HttpClient _client;
        public DogCatcherRepository()
        {
            _client = new HttpClient();
        }
        public async Task<bool> Post(DogCatcherCreate dogCatcher,string URL)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL);
            if (dogCatcher is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogCatcher), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<List<DogCatcherListItem>> Get(string URL)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DogCatcherListItem>>(content);
            }
            return null;
        }
        public async Task<DogCatcherDetail> Get(string URL, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DogCatcherDetail>(content);
            }
            return null;
        }
        public async Task<bool> Put(DogCatcherEdit dogCatcher, string URL, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL);
            if (dogCatcher is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogCatcher), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string URL, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
