using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.HumanResourcesHubServices
{
    public class HumanResourcesHubService
    {
        private readonly HttpClient _client;
        private readonly ApplicantRepository applicantRepo;
      //  private readonly Guid _userID;
        //public HumanResourcesHubService(Guid userId)
        //{
        //    _userID = userId;
        //    _client = new HttpClient();
        //}

        public HumanResourcesHubService()
        {
            _client = new HttpClient();
            applicantRepo = new ApplicantRepository(_client);
        }
        public async Task<List<ApplicantListItem>> Get(string URL)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL);
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ApplicantListItem>>(content);
            }
            return null;
        }
        public async Task<ApplicantDetail> Get(string URL, int id)
        {
            var applicant =await applicantRepo.GetApplicantByID(URL, id);
            if (applicant is null)
            {
                return null;
            }
            return applicant;
        }
    }
}