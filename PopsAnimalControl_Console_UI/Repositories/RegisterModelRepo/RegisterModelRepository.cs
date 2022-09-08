using Newtonsoft.Json;
using PopsAnimalControl_Console_UI.DataModels.ApplicationUsers;
using PopsAnimalControl_Console_UI.Utilities;
using PopsAnimalControl_Console_UI.ViewModels.RegisterBindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.Repositories.RegisterModelRepo
{
    public class RegisterModelRepository
    {
        private HttpClient _client;
        public RegisterModelRepository()
        {
            _client = new HttpClient();
        }
        public async Task<bool> Post(RegisterBindingModel model,string URL)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL);
            if (model is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, ApiMessenger.ApplicationUsers);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ApplicationUser>>(content);
            }
            return null;
        }
    }
}
