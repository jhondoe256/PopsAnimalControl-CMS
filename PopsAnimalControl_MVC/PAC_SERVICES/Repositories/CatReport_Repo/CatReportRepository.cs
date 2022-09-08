using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.CatReportViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.CatReport_Repo
{
    public class CatReportRepository
    {
        private HttpClient _client;
        public CatReportRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<CatReportListItem>> Get(string URL, string email)
        {
            var requrest = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(requrest);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CatReportListItem>>(content);
            }
            return null;
        }
        public async Task<CatReportDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CatReportDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, CatReportCreate cat)
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
        public async Task<bool> Put(string URL, string email, CatReportEdit cat, int id)
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
        //public async Task<bool> Delete(string URL, string email, int id)
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Delete, URL + id + "/" + id);
        //    var response = await _client.SendAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}