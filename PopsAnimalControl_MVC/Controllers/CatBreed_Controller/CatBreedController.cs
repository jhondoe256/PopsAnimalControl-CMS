using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.CatBreedViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.CatBreedServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.CatBreed_Controller
{
    public class CatBreedController : Controller
    {
        private Guid userID;
        private CatBreedService CreateCatBreedService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatBreedService();
            return svc;
        }
        // GET: CatBreed
        public async Task<ActionResult> Index()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breeds = await svc.Get(ApiMessenger.CatBreed, exEmail);
                return View(breeds);
            }
        }
        //GET: CatBreed/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breed = await svc.Get(ApiMessenger.CatBreed, exEmail, id);
                return View(breed);
            }
        }
        //GET: CatBreed/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: CatBreed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatBreedCreate catBreed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.CatBreed, exEmail, catBreed);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: CatBreed/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breed = await svc.Get(ApiMessenger.CatBreed, exEmail, id);
                var conversion = new CatBreedEdit
                {
                    CoatTypeAndLength=breed.CoatTypeAndLength,
                    LocationAndOrigin=breed.LocationAndOrigin,
                    BodyType=breed.BodyType,
                    Breed=breed.Breed,
                    Cat_BreedID=breed.Cat_BreedID,
                    CoatPattern=breed.CoatPattern,
                    Type=breed.Type,
                };
                return View(conversion);
            }
        }
        //POST: CatBreed/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatBreedEdit catBreed, int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.CatBreed, exEmail,catBreed, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: CatBreed/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breed = await svc.Get(ApiMessenger.CatBreed, exEmail, (int)id);
                return View(breed);
            }
        }
        //POST: CatBreed/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.CatBreed, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
    }
}