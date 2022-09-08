using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.DogCatcherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogCatcher_Repo
{
    public class DogCatcherRepo
    {
        private HttpClient _client;
        public DogCatcherRepo(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<DogCatcherListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DogCatcherListItem>>(content);
            }
            return null;
        }
        public async Task<DogCatcherDetails> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DogCatcherDetails>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, DogCatcherCreate dogCatcher)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (dogCatcher is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogCatcher), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, DogCatcherEdit dogCatcher, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (dogCatcher is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogCatcher), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
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