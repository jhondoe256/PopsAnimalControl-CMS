using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.DogCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.DepartmentServices;
using PopsAnimalControl_MVC.PAC_SERVICES.DogCatcherServices;
using PopsAnimalControl_MVC.PAC_SERVICES.HumanResourcesHubServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.DogCather_Controller
{
    public class DogCatcherController : Controller
    {
        private Guid userID;

        private DogCatcherService CreateDogCatcherService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogCatcherService();
            return svc;
        }
        // GET: DogCatcher
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var dogCatchers = await svc.Get(ApiMessenger.DogCatcher, extEmail);
                return View(dogCatchers);
            }
        }
        //GET: DogCatcher/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dogCatcher = await svc.Get(ApiMessenger.DogCatcher, exEmail, id);
                return View(dogCatcher);
            }
        }
        //GET: DogCatcher/Create
        public async Task<ActionResult> Create()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svcA = CreateDogCatcherService();
                var svc2 = new DepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var departments = await svc2.Get(ApiMessenger.Department, extEmail,1);
                var svc = new HumanResourcesHubService();
                var dogCatchers = await svc.Get(ApiMessenger.DogCatcherApplicants);
                var conversion = new DogCatcherCreate
                {
                    DogCatcherApplicants = dogCatchers.ToList(),
                    DogCatcherDepartments=departments.Department_Positions.ToList()
                    
                };
                return View(conversion);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DogCatcherCreate dogCatcher)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (dogCatcher is null)
                {
                    return HttpNotFound();
                }
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);

                var success = await svc.Post(ApiMessenger.DogCatcher, exEmail, dogCatcher);

                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: DogCatcher/Edit
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dogCatcher = await svc.Get(ApiMessenger.DogCatcher, exEmail, id);
                var conversion = new DogCatcherEdit
                {
                    EmployeeID = dogCatcher.EmployeeID,
                    FirstName = dogCatcher.FirstName,
                    LastName = dogCatcher.LastName,
                };
                return View(conversion);
            }
        }
        //POST: DogCathcher/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DogCatcherEdit dogCatcher, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.DogCatcher, exEmail, dogCatcher, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: DogCatcher/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var dogCatcher = await svc.Get(ApiMessenger.DogCatcher, exEmail, (int)id);
                return View(dogCatcher);
            }
        }
        //POST: DogCatcher/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.DogCatcher, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }

    }
}