using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.DogData.Breeds;
using PopsAnimalControl_MVC.Models.ViewModels.BreedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogBreed_Repo
{
    public class DogBreedRepository
    {
        private HttpClient _client;
        public DogBreedRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<DogBreedListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DogBreedListItem>>(content);
            }
            return null;
        }
        public async Task<DogBreedDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DogBreedDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, DogBreedCreate dogBreed)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);

            if (dogBreed is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogBreed), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, DogBreedEdit dogBreed, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (dogBreed is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogBreed), Encoding.UTF8, "application/json");
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