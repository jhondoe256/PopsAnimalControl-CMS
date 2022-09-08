using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.BreedViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.BreedServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.DogBreed_Controller
{
    public class DogBreedController : Controller
    {
        private Guid userID;
        private DogBreedService CreateDogBreedService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogBreedService();
            return svc;
        }

        // GET: DogBreed
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var Breeds = await svc.Get(ApiMessenger.DogBreed, exEmail);
                return View(Breeds);
            }
        }

        //GET: DogBreed/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dogBreed = await svc.Get(ApiMessenger.DogBreed, exEmail, id);
                return View(dogBreed);
            }
        }
        //GET: DogBreed/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: DogBreed/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DogBreedCreate dogBreed)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.DogBreed, exEmail, dogBreed);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: DogBreed/Edit
        public async Task<ActionResult> Edit( int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breed = await svc.Get(ApiMessenger.DogBreed, exEmail, id);
                var conversion = new DogBreedEdit
                {
                    BreedID=breed.BreedID,
                    BreedName=breed.BreedName,
                    Country=breed.Country,
                    Section=breed.Section
                };
                return View(conversion);
            }
        }
        //POST: DogBreed/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Edit(DogBreedEdit dogBreedEdit, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.DogBreed, exEmail, dogBreedEdit, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: DogBreed/Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var breed = await svc.Get(ApiMessenger.DogBreed, exEmail, (int)id);
                return View(breed);
            }
        }
        //POST: DogBreed/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogBreedService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.DogBreed, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}