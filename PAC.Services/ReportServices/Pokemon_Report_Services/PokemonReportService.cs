using PAC.Data.Reports.PokemonReports;
using PAC.Models.PokemonCatcherModels;
using PAC.Models.PokemonModels;
using PAC.Models.ReportModels.PokemonReportModels;
using PAC.Services.PokemonServices;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ReportServices.Pokemon_Report_Services
{
    public class PokemonReportService
    {
        private readonly Guid _userId;
        private readonly PokemonService _pService;
        public PokemonReportService(Guid userId)
        {
            _userId = userId;
            _pService = new PokemonService(userId);
        }
        public async Task<IEnumerable<PokemonReportListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                var pokeReports =
                    await
                    ctx
                    .PokemonReports
                 //   .Where(p => p.OwnerID == _userId)
                    .Select(p => new PokemonReportListItem
                    {
                        ReportID = p.ReportID,
                        EmployeeID = p.EmployeeID,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        CreationDate = p.CreationDate,
                    }).ToListAsync();

                return pokeReports;
            }
        }
        public async Task<PokemonReportDetails> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = await ctx.PokemonReports.SingleOrDefaultAsync(p => p.ReportID == id);
                if (report is null)
                {
                    return null;
                }
                var employee = await ctx.PokemonCatchers.SingleOrDefaultAsync(e => e.EmployeeID == report.EmployeeID);
                if (employee is null)
                {
                    return null;
                }
                var pokeReport =
                    await
                    ctx
                    .PokemonReports
                  //  .Where(p => p.OwnerID == _userId)
                    .SingleOrDefaultAsync(p => p.ReportID == id);

                if (pokeReport is null)
                {
                    return null;
                }

                return new PokemonReportDetails
                {
                    ReportID = pokeReport.ReportID,
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PositionTitle = ctx.Positions.SingleOrDefault(p => p.PositionID == employee.PositionID).Name,
                    PokemonBirthName=pokeReport.PokemonBirthName,
                    name = pokeReport.name,
                    Age = pokeReport.Age,
                    DateOfBirth = pokeReport.DateOfBirth,
                    DateOfCapture = pokeReport.DateOfCapture,
                    HasCollarIdentification = pokeReport.HasCollarIdentification,
                    HasChipIdentification = pokeReport.HasChipIdentification,
                    TempermentType = pokeReport.TempermentType.ToString(),
                    InjurySeverityType = pokeReport.InjurySeverityType.ToString(),
                    EventDescription = pokeReport.EventDescription,
                    CaptureWorth = pokeReport.CaptureWorth,
                    CreationDate = pokeReport.CreationDate,
                    ModificationionDate = pokeReport.ModificationionDate
                };
            }
        }
        public async Task<bool> Post(PokemonReportCreate pokemonReport)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee = await ctx.PokemonCatchers.SingleOrDefaultAsync(e => e.EmployeeID == pokemonReport.EmployeeID);
                if (employee is null)
                {
                    return false;
                }
                var pokemonData = await _pService.GetPokeDataFromApi(pokemonReport.name);
                if (pokemonData is null)
                {
                    return false;
                }
                if (pokemonData.name==null)
                {
                    return false;
                }
                var entity = new PokemonReport
                {
                    OwnerID = _userId,
                    EmployeeID = pokemonReport.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PokemonBirthName=pokemonReport.PokemonBirthName,
                    DateOfBirth = pokemonReport.DateOfBirth,
                    DateOfCapture = DateTime.Now,
                    HasCollarIdentification = pokemonReport.HasCollarIdentification,
                    HasChipIdentification = pokemonReport.HasChipIdentification,
                    TempermentType = pokemonReport.TempermentType,
                    InjurySeverityType = pokemonReport.InjurySeverityType,
                    name = pokemonData.name,
                    EventDescription = pokemonReport.EventDescription,
                    CaptureWorth = pokemonReport.CaptureWorth,
                    CreationDate = DateTime.Now,

                };

                ctx.PokemonReports.Add(entity);
                if (await ctx.SaveChangesAsync() == 1)
                {
                    var pokeEntity = new PokemonCreate
                    {
                        name=entity.name,
                        PokemonBirthName=pokemonReport.PokemonBirthName,
                        PokemonTypeName=pokemonReport.name,
                        CaptureWorth = pokemonReport.CaptureWorth,
                        DateOfBirth = pokemonReport.DateOfBirth,
                        DateOfCapture = DateTime.Now,
                        HasChipIdentification = pokemonReport.HasChipIdentification,
                        HasCollarIdentification = pokemonReport.HasCollarIdentification,
                        InjuryServerityType = pokemonReport.InjurySeverityType,
                        TempermentType = pokemonReport.TempermentType,
                        ReportID = entity.ReportID,
                        PokemonReport = entity
                    };

                    return await _pService.Post(pokeEntity);

                }
                return false;
            }
        }
        public async Task<bool> Put(PokemonReportEdit pokemonReport, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldReportData = await ctx.PokemonReports.FindAsync(id);

                if (oldReportData is null)
                {
                    return false;
                }
                var oldPokeData = ctx.Pokemons.SingleOrDefault(p => p.PokemonBirthName == oldReportData.PokemonBirthName);

                if (oldPokeData is null)
                {
                    return false;
                }

                //var oldDogID = oldPokeData.id;


                oldReportData.PokemonBirthName = pokemonReport.PokemonBirthName;
                oldReportData.CaptureWorth = pokemonReport.CaptureWorth;
                oldReportData.DateOfBirth = pokemonReport.DateOfBirth;
                oldReportData.DateOfCapture = oldPokeData.DateOfCapture;
                oldReportData.EmployeeID = pokemonReport.EmployeeID;
               
                var employee = ctx.PokemonCatchers.SingleOrDefault(e => e.EmployeeID == pokemonReport.EmployeeID);

                if (employee is null)
                {
                    return false;
                }
                oldReportData.FirstName = employee.FirstName;
                oldReportData.LastName = employee.LastName;
                oldReportData.name = pokemonReport.name;
                oldReportData.TempermentType = pokemonReport.TempermentType;
                oldReportData.InjurySeverityType = pokemonReport.InjurySeverityType;
                oldReportData.HasChipIdentification = pokemonReport.HasChipIdentification;
                oldReportData.HasCollarIdentification = pokemonReport.HasCollarIdentification;
                oldReportData.ModificationionDate = DateTime.Now;
                oldReportData.EventDescription = pokemonReport.EventDescription;

                oldPokeData.PokemonBirthName = pokemonReport.PokemonBirthName;
                oldPokeData.name = pokemonReport.name;
                oldPokeData.HasChipIdentification = pokemonReport.HasChipIdentification;
                oldPokeData.HasCollarIdentification = pokemonReport.HasCollarIdentification;
                oldPokeData.TempermentType = pokemonReport.TempermentType;
                oldPokeData.DateOfCapture = oldPokeData.DateOfCapture;
                oldPokeData.DateOfBirth = pokemonReport.DateOfBirth;
                oldPokeData.CaptureWorth = pokemonReport.CaptureWorth;
                oldPokeData.InjurySeverityType = pokemonReport.InjurySeverityType;


                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var report = await ctx.PokemonReports.SingleOrDefaultAsync(p => p.ReportID == id);
                if (report is null)
                {
                    return false;
                }
                ctx.PokemonReports.Remove(report);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
