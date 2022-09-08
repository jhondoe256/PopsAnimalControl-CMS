﻿using Newtonsoft.Json;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PopsAnimalControl_MVC.PAC_SERVICES.Repositories.Pokemon_Repo
{
    public class PokemonRepository
    {
        private HttpClient _client;
        public PokemonRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<PokemonListItem>> Get(string URL, string email) 
        {
            var request = new HttpRequestMessage(HttpMethod.Get,URL+email);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PokemonListItem>>(content);
            }
            return null;
        }
        public async Task<PokemonDetail> Get(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PokemonDetail>(content);
            }
            return null;
        }
        public async Task<bool> Post(string URL, string email, PokemonCreate pokemon)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, URL + email);
            if (pokemon is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemon), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Put(string URL, string email, PokemonEdit pokemon, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, URL + email + "/" + id);
            if (pokemon is null)
            {
                return false;
            }
            request.Content = new StringContent(JsonConvert.SerializeObject(pokemon), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(string URL, string email, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, URL + email + "/" + id);
            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}