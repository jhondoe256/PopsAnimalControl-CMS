using Newtonsoft.Json;
using PAC.Data.Animals.Pokemon;
using PAC.Data.Animals.Pokemon.PokemonAbilities;
using PAC.Models.PokemonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.Pokemon_Utilities
{
    public static class PokemonUtility
    {
        private static HttpClient _client = new HttpClient();
        private static string BaseUrl = "https://pokeapi.co/api/v2";
        private static string Pokemon = $"{BaseUrl}/pokemon/";
//        public static async Task<PokemonDetail> GetPokemon(int pokeID)
        //{
        //    if (pokeID < 1)
        //    {
        //        return null;
        //    }
        //    HttpResponseMessage response = await _client.GetAsync($"{Pokemon}{pokeID}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var pokemon = JsonConvert.DeserializeObject<PokemonDetail>(content);
        //        return new PokemonDetail
        //        {
        //            abilities = pokemon.abilities,
        //            moves = pokemon.moves,
        //            forms = pokemon.forms
        //        };
               
        //    }
        //    return null;
        //}
        public static async Task<PokemonDetail> GetPokemon(string pokeID)
        {
            if (pokeID == null)
            {
                return null;
            }
            HttpResponseMessage response = await _client.GetAsync($"{Pokemon}{pokeID}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pokemon = JsonConvert.DeserializeObject<PokemonDetail>(content);
                return new PokemonDetail
                {
                    name=pokemon.name,
                    abilities = pokemon.abilities,
                    moves = pokemon.moves,
                    forms = pokemon.forms
                };
              
            }
            return null;
        }
    }
}
