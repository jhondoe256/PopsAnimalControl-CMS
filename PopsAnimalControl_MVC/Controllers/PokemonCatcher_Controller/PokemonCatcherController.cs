using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.DepartmentServices;
using PopsAnimalControl_MVC.PAC_SERVICES.HumanResourcesHubServices;
using PopsAnimalControl_MVC.PAC_SERVICES.PokemonCatcherServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.PokemonCatcher_Controller
{
    public class PokemonCatcherController : Controller
    {
        private Guid userID;
        private PokemonCatcherService CreatePCService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonCatcherService();
            return svc;
        }
        // GET: PokemonCatcher
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pCatchers = await svc.Get(ApiMessenger.PokemonCatcher, exEmail);
                return View(pCatchers);
            }
        }
        //GET: PokemonCatcher/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pCatcher = await svc.Get(ApiMessenger.PokemonCatcher, exEmail, id);
                return View(pCatcher);
            }
        }
        //Get: PokemonCatcher/Create
        public async Task<ActionResult> Create()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svcA = CreatePCService();
                var svc2 = new DepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var departments = await svc2.Get(ApiMessenger.Department, extEmail, 3);
                var svc = new HumanResourcesHubService();
                var dogCatchers = await svc.Get(ApiMessenger.PokemonCatcherApplicants);
                var conversion = new PokemonCatcherCreate
                {
                    PokemonCatcherApplicants = dogCatchers.ToList(),
                    PokemonCatcherDepartments = departments.Department_Positions.ToList()

                };
                return View(conversion);
            }
        }
        //POST: PokemonCatcher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PokemonCatcherCreate pokemonCatcher) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.PokemonCatcher, exEmail, pokemonCatcher);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: PokemonCatcher/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pCatcher = await svc.Get(ApiMessenger.PokemonCatcher, exEmail, id);
                var conversion = new PokemonCatcherEdit
                {
                    EmployeeID=pCatcher.EmployeeID,
                    FirstName=pCatcher.FirstName,
                    LastName=pCatcher.LastName
                };
                return View(conversion);
            }
        }
        //POST: PokemonCatcher/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PokemonCatcherEdit pokemonCatcher, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.PokemonCatcher, exEmail, pokemonCatcher, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: PokemonCatcher/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var pCatcher = await svc.Get(ApiMessenger.PokemonCatcher, exEmail, (int)id);
                return View(pCatcher);
            }
        }
        //POST: PokemonCatcher/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePCService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.PokemonCatcher, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
    }
}