using PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Position_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.PositionServices
{
    public class PositionService
    {
        private PositionRepository _repo;
        private HttpClient _client;
        public PositionService()
        {
            _client = new HttpClient();
            _repo = new PositionRepository(_client);
        }
        public async Task<List<PositionListItem>> Get(string url, string email)
        {
            var positions = await _repo.Get(url,email);
            return positions;
        }
        public async Task<PositionDetail> Get(string url, string email, int id)
        {
            var position = await _repo.Get(url, email, id);
            return position;
        }
        public async Task<bool> Post(string url, string email, PositionCreate position)
        {
            var success = await _repo.Post(url, email, position);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string url, string email, PositionEdit position, int id)
        {
            var success = await _repo.Put(url, email, position, id);
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