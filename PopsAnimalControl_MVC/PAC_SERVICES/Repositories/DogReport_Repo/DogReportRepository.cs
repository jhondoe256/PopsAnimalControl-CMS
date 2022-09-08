using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.DogReport_Repo
{
    public class DogReportRepository
    {
        private HttpClient _client;
        public DogReportRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<DogReportListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DogReportListItem>>(content);
            }
            return null;
        }
        public async Task<DogReportDetails> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DogReportDetails>(content);
            }
            return null;
        }
        public async Task<bool> Put(string URL, string email, DogReportEdit dogReportEdit, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (dogReportEdit is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogReportEdit), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Post(string URL, string email, DogReportCreate dogReport)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (dogReport is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(dogReport), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        //public async Task<bool> Delete(string URL, string email, int id)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Delete, URL + email + "/" + id);
        //    var response = await _client.SendAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}