using Newtonsoft.Json;
using PopsAnimalControl_Console_UI.ViewModels.TokenViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.Repositories.TokenModelRepo
{
    public class TokenModelRepository
    {
        private HttpClient _client;
        public TokenModelRepository()
        {
            _client = new HttpClient();
        }
        public async Task<bool> Post(TokenViewModel token, string URL)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL);
            request.Content = new StringContent(JsonConvert.SerializeObject(token),Encoding.UTF8,"application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                //token.Token =await response.Content.ReadAsStringAsync();
                return true;
            }
            return false;
        }
    }
}
