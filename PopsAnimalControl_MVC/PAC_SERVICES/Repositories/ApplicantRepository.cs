using Newtonsoft.Json;
using PopsAnimalControl_MVC.Contracts.IRepository.IApplicantRepo;
using PopsAnimalControl_MVC.Models.DataModels.ApplicantData;
using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories
{
    public class ApplicantRepository 
    {
        private readonly HttpClient _client;
        public ApplicantRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Create(string URL, ApplicantCreate entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL);
           
            if (entity is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            HttpResponseMessage response= await _client.SendAsync(request);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> Delete(string URL, int id)
        {
            if (id<1)
            {
                return false;
            }
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + id);
            HttpResponseMessage response = await _client.SendAsync(request);

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public async Task<ApplicantDetail> GetApplicantByID(string URL,int id)
        {
            if (id<1)
            {
                return null;
            }
            var request = new HttpRequestMessage(HttpMethod.Get, URL + id);
            var response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApplicantDetail>(content);
            }
            return null;
            
        } 
        public async Task<ApplicantDetail> GetApplicantByEmail(string URL,string email)
        {
            if (email is null)
            {
                return null;
            }
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email);
            var response = await _client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApplicantDetail>(content);
            }
            return null;
            
        }


        public async Task<bool> Update(string URL, int id, ApplicantEdit entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + id);
            if (entity is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateViaEmail(string URL, string email, ApplicantEdit entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email);
            if (entity is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}