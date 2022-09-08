using PAC.Data.Animals.Pokemon;
using PAC.Models.PokemonModels;
using PAC.Models.ReportModels.PokemonReportModels;
using PAC.Services.Pokemon_Utilities;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.PokemonServices
{
    public class PokemonService
    {
        private readonly Guid _userId;
        public PokemonService(Guid userId)
        {
            _userId = userId;
        }
        //private async Task<PokemonDetail> GetPokeDataFromApi(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var pokemon = await PokemonUtility.GetPokemon(id);
        //        if (pokemon is null)
        //        {
        //            return null;
        //        }
        //        return pokemon;
        //    }
        //}
        public async Task<PokemonDetail> GetPokeDataFromApi(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemon = await PokemonUtility.GetPokemon(id);
                if (pokemon is null)
                {
                    return null;
                }
                return pokemon;
            }
        }
        public async Task<bool> Post(PokemonCreate pokemon)
        {

            var pokemonData = await GetPokeDataFromApi(pokemon.name);
            if (pokemonData is null)
            {
                return false;
            }
            var entity = new Pokemon
            {
                OwnerID = _userId,
                PokemonBirthName = pokemon.PokemonBirthName,
                name = pokemonData.name,
                DateOfBirth = pokemon.DateOfBirth,
                DateOfCapture = DateTime.Now,
                HasCollarIdentification = pokemon.HasCollarIdentification,
                HasChipIdentification = pokemon.HasChipIdentification,
                TempermentType = pokemon.TempermentType,
                InjurySeverityType = pokemon.InjuryServerityType,
                CaptureWorth = pokemon.CaptureWorth,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pokemons.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Put(PokemonEdit pokemon, int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var oldPokeData = await ctx.Pokemons.FindAsync(id);
                if (oldPokeData is null)
                {
                    return false;
                }
                oldPokeData.PokemonBirthName = pokemon.PokemonBirthName;
                oldPokeData.DateOfBirth = (pokemon.DateOfBirth == null) ? oldPokeData.DateOfBirth : pokemon.DateOfBirth;
                oldPokeData.DateOfCapture = (pokemon.DateOfCapture == null) ? oldPokeData.DateOfCapture : pokemon.DateOfCapture;
                oldPokeData.HasChipIdentification = pokemon.HasChipIdentification;
                oldPokeData.HasCollarIdentification = pokemon.HasCollarIdentification;
                oldPokeData.InjurySeverityType = pokemon.InjurySeverityType;
                oldPokeData.TempermentType = pokemon.TempermentType;
                oldPokeData.CaptureWorth = pokemon.CaptureWorth;
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<IEnumerable<PokemonListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pokemon_s = await
                    ctx
                    .Pokemons
                //    .Where(p => p.OwnerID == _userId)
                    .Select(p => new PokemonListItem
                    {
                        id=p.PokeID,
                        PokemonBirthName=p.PokemonBirthName,
                        PokemonBreedName=p.name
                    }).ToListAsync();

                return pokemon_s;
            }
        }
        public async Task<PokemonDetail> Get(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var pokemon_s = 
                    await
                    ctx
                    .Pokemons
               //     .Where(p => p.OwnerID == _userId)
                    .SingleOrDefaultAsync(p => p.PokeID == id);

                if (pokemon_s is null)
                {
                    return null;
                }
                var pokemonData = await PokemonUtility.GetPokemon(pokemon_s.name);
                if (pokemonData is null)
                {
                    return null;
                }
                if (pokemonData.name is null)
                {
                    return null;
                }
                var report = ctx.PokemonReports.FirstOrDefault(p => p.PokemonBirthName == pokemon_s.PokemonBirthName);
                if (report is null)
                {
                    return null;
                }
                var employee = await ctx.PokemonCatchers.SingleOrDefaultAsync(e => e.EmployeeID == report.EmployeeID);
                if (employee is null)
                {
                    return null;
                }
                return new PokemonDetail 
                {
                    PokeID=pokemon_s.PokeID,
                    name=pokemon_s.name,
                    PokemonBirthName=pokemon_s.PokemonBirthName,
                    Age=pokemon_s.Age,
                    DateOfBirth=pokemon_s.DateOfBirth,
                    forms=pokemonData.forms,
                    abilities=pokemonData.abilities,
                    moves=pokemonData.moves,
                    HasCollarIdentification=pokemon_s.HasCollarIdentification,
                    HasChipIdentification=pokemon_s.HasChipIdentification,
                    InjurySeverityType = pokemon_s.InjurySeverityType,
                    TempermentType=pokemon_s.TempermentType,
                    DateOfCapture=pokemon_s.DateOfCapture,
                    CaptureWorth=pokemon_s.CaptureWorth,
                    PokeReport=new PokemonReportListItem 
                    {
                        ReportID=report.ReportID,
                        EmployeeID=employee.EmployeeID,
                        FirstName=employee.FirstName,
                        LastName=employee.LastName,
                        CreationDate=report.CreationDate
                    }
                };
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldPokeData = await ctx.Pokemons.FindAsync(id);
                if (oldPokeData is null)
                {
                    return false;
                }
                ctx.Pokemons.Remove(oldPokeData);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
