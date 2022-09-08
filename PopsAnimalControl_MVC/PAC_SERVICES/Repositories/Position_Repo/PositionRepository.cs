using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Position_Repo
{
    public class PositionRepository
    {
        private HttpClient _client;
        public PositionRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<PositionListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PositionListItem>>(content);
            }
            return null;
        }
        public async Task<PositionDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PositionDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, PositionCreate position)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (position is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(position), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email,PositionEdit position, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (position is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(position), Encoding.UTF8, "application/json");
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
            if (response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}