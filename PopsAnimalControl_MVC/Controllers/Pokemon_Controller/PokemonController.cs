using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.PokemonServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Pokemon_Controller
{
    public class PokemonController : Controller
    {
        private Guid userID;
        private PokemonService CreatePokemonService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonService();
            return svc;
        }
        // GET: Pokemon
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pokemonGrp = await svc.Get(ApiMessenger.Pokemon, exEmail);
                return View(pokemonGrp);
            }
        }
        //GET: Pokemon/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pokemon = await svc.Get(ApiMessenger.Pokemon, exEmail, id);
                return View(pokemon);
            }
        }
        //GET: Pokemon/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Pokemon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PokemonCreate pokemon)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.Pokemon, exEmail, pokemon);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: Pokemon/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pokemon = await svc.Get(ApiMessenger.Pokemon, exEmail, id);
                var conversion = new PokemonEdit
                {
                    Age = pokemon.Age,
                    CaptureWorth = pokemon.CaptureWorth,
                    DateOfBirth = pokemon.DateOfBirth,
                    DateOfCapture = pokemon.DateOfCapture,
                    HasChipIdentification = pokemon.HasChipIdentification,
                    HasCollarIdentification = pokemon.HasCollarIdentification,
                    InjurySeverityType = pokemon.InjurySeverityType,
                    name = pokemon.name,
                    PokeID = pokemon.PokeID,
                    PokemonBirthName = pokemon.PokemonBirthName,
                    TempermentType = pokemon.TempermentType,
                    PokeReportID = pokemon.PokeReport.ReportID
                };
                return View(conversion);
            }
        }
        //POST: Pokemon/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PokemonEdit pokemon, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.Pokemon, exEmail, pokemon, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: Pokemon/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pokemon = await svc.Get(ApiMessenger.Pokemon, exEmail, (int)id);
                return View(pokemon);
            }
        }
        //POST: Post/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePokemonService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.Pokemon, exEmail,id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}
