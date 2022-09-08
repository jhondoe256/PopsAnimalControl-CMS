using PopsAnimalControl_Console_UI.Repositories.DogCatcherRepo;
using PopsAnimalControl_Console_UI.ViewModels.DogCatcherViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.PAC_SERVICES.DogCatcherServices
{
    public class DogCatcherService
    {
        
        private DogCatcherRepository _repo;
      
        public DogCatcherService()
        {
            _repo = new DogCatcherRepository();
        }
        public async Task<bool> Post(DogCatcherCreate dogCatcher, string url)
        {
            var success = await _repo.Post(dogCatcher, url);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string url, int id)
        {
            var success = await _repo.Delete(url, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(DogCatcherEdit dogCatcher, string url, int id)
        {
            var success = await _repo.Put(dogCatcher, url, id);
            if (success)
            {
                return true;
            }
            return false;
        }
        public async Task<List<DogCatcherListItem>> Get(string url)
        {
            var dogCatchers = await _repo.Get(url);
            return dogCatchers;
        }
        public async Task<DogCatcherDetail> Get(string url,int id)
        {
            var dogCatcher = await _repo.Get(url, id);
            return dogCatcher;
        }
    }
}
