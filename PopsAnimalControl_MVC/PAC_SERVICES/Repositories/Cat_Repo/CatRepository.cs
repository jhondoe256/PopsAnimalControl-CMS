using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.CatViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Cat_Repo
{
    public class CatRepository
    {
        private HttpClient _client;
        public CatRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<CatListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CatListItem>>(content);
            }
            return null;
        }
        public async Task<CatDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, CatCreate cat)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (cat is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(cat), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, CatEdit cat, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (cat is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(cat), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string URL, string email,int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + email+"/"+id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}