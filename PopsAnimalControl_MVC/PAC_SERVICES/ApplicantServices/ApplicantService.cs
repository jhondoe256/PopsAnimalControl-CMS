using PopsAnimalControl_MVC.Models.DataModels.ApplicantData;
using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.ApplicantServices
{
    public class ApplicantService
    {
        private readonly HttpClient _client;
      //  private readonly Guid _userID;
        private readonly ApplicantRepository _repo;
        
        public ApplicantService()
        {
        //    _userID = userID;
            _client = new HttpClient();
            _repo = new ApplicantRepository(_client);
        }
       
        public async Task<bool> CreateApplicant(string url, ApplicantCreate applicantCreate)
        {
            var isSuccessful = await _repo.Create(url, applicantCreate);
            return isSuccessful;
        }
        public async Task<ApplicantDetail> GetApplicant(string url, int id)
        {
            var applicant = await _repo.GetApplicantByID(url, id);
            return applicant;
        }
        public async Task<ApplicantDetail> GetApplicantByEmail(string url, string email)
        {
            var applicant = await _repo.GetApplicantByEmail(url, email);
            return applicant;
        }
        public async Task<bool> UpdateApplicant(string url, int id, ApplicantEdit applicant)
        {
            var isSuccessful = await _repo.Update(url, id, applicant);
            return isSuccessful;
        }
        public async Task<bool> UpdateApplicantViaEmail(string url, string email, ApplicantEdit applicant)
        {
            var isSuccessful = await _repo.UpdateViaEmail(url, email, applicant);
            return isSuccessful;
        }
        public async Task<bool> DeleteApplicant(string url, int id)
        {
            var isSuccessful = await _repo.Delete(url, id);
            return isSuccessful;
        }
    }
}