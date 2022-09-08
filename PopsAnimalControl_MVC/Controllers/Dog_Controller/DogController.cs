using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.DogViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.DogServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Dog_Controller
{
    public class DogController : Controller
    {
        private Guid userID;
        private DogService CreateDogService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogService();
            return svc;
        }
        // GET: Dog
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dogs = await svc.Get(ApiMessenger.Dog,exEmail);
                return View(dogs);
            }
        }
        //GET: Dog/Details
        public async Task<ActionResult>Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dog = await svc.Get(ApiMessenger.Dog, exEmail, id);
                return View(dog);
            }
        }
        //GET: Dog/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Dog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post(DogCreate dog)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(userID.ToString());
                var success = await svc.Post(ApiMessenger.Dog, exEmail, dog);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: Dog/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dog = await svc.Get(ApiMessenger.Dog, exEmail, id);
                var conversion = new DogEdit
                {
                    BreedID=dog.BreedID,
                    CaptureWorth=dog.CaptureWorth,
                    DateOfBirth=dog.DateOfBirth,
                    DateOfCapture=dog.DateOfCapture,
                    HasChipIdentification=dog.HasChipIdentification,
                    HasCollarIdentification=dog.HasCollarIdentification,
                    ID=dog.ID,
                    Name=dog.Name,
                    ReportID=dog.DogReport.ReportID,
                };
                return View(conversion);
            }
        }
        //POST: Dog/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id , DogEdit dog)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.Dog, exEmail, dog, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: Dog/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dog = await svc.Get(ApiMessenger.Dog, exEmail, (int)id);
                return View(dog);
            }
        }
        //POST: Dog/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateDogService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.Dog, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }

 
    }
}