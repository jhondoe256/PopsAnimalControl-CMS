using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Department_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.DepartmentServices
{
    public class DepartmentService
    {
        private DepartmentRepository _repo;
        private HttpClient _client;

        public DepartmentService()
        {
            _client = new HttpClient();
            _repo = new DepartmentRepository(_client);
        }

        public async Task<IEnumerable<DepartmentListItem>> Get(string url,string email)
        {
            var departments = await _repo.Get(url, email);
            return departments;
        }
        public async Task<DepartmentDetail> Get(string url, string email, int id)
        {
            var department = await _repo.Get(url, email, id);
            return department;
        }
        public async Task<bool> Post(string url, string email, DepartmentCreate department)
        {
            var success =await _repo.Create(url, email, department);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, DepartmentEdit department,int id)
        {
            var success = await _repo.Update(url, email, department,id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string url, string email, int id)
        {
            var success = await _repo.Delete(url, email, id);
            if (success)
            {
                return true;
            }
            return false;
        }

    }
}