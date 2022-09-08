using Newtonsoft.Json;
using PopsAnimalControl_MVC.Contracts.IRepository;
using PopsAnimalControl_MVC.Contracts.IRepository.IDepartmentRepo;
using PopsAnimalControl_MVC.Models.DataModels.DepartmentData;
using PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Department_Repo
{
    public class DepartmentRepository
    {
        private HttpClient _client;
        public DepartmentRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<bool> Create(string URL, string email, DepartmentCreate entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (entity is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<DepartmentDetail> Get(string URL, string email, int id)   
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/"+ id);
            var response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DepartmentDetail>(content);
            }
            return null;
        }
        public async Task<List<DepartmentListItem>> Get(string URL, string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DepartmentListItem>>(content);
            }
            return null;
        }
        public async Task<bool> Update(string URL, string email, DepartmentEdit entity, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (entity is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.StatusCode==HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string URL, string email,int id)
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