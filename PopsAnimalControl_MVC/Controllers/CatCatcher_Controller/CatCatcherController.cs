using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.CatCatcherViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.CatCatcherServices;
using PopsAnimalControl_MVC.PAC_SERVICES.DepartmentServices;
using PopsAnimalControl_MVC.PAC_SERVICES.HumanResourcesHubServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.CatCatcher_Controller
{
    public class CatCatcherController : Controller
    {
        private Guid userID;
        private CatCatcherService CreateCatCatcherService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatCatcherService();
            return svc;
        }

        // GET: CatCatcher
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var catCatchers = await svc.Get(ApiMessenger.CatCatcher, exEmail);
                return View(catCatchers);
            }
        }
        //GET: CatCatcher/Detail
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var catCatcher = await svc.Get(ApiMessenger.CatCatcher, exEmail, id);
                return View(catCatcher);
            }
        }
        //GET: CatCatcher/Create
        public async Task<ActionResult> Create()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svcA = CreateCatCatcherService();
                var svc2 = new DepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var departments = await svc2.Get(ApiMessenger.Department, extEmail, 2);
                var svc = new HumanResourcesHubService();
                var CatCatchers = await svc.Get(ApiMessenger.CatCatcherApplicants);
                var conversion = new CatCatcherCreate
                {
                    CatCatcherApplicants = CatCatchers.ToList(),
                    CatCatcherDepartments = departments.Department_Positions.ToList()

                };
                return View(conversion);
            }
        }
        //POST: CatCatcher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatCatcherCreate catCatcher)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.CatCatcher, exEmail,catCatcher);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: CatCatcher/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var catCatcher = await svc.Get(ApiMessenger.CatCatcher, exEmail, id);
                var catCatcherConversion = new CatCatcherEdit
                {
                    EmployeeID=catCatcher.EmployeeID,
                    FirstName=catCatcher.FirstName,
                    LastName=catCatcher.LastName,
                };
                return View(catCatcherConversion);
            }
        }
        //POST: CatCatcher/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatCatcherEdit catCatcher, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.CatCatcher, exEmail, catCatcher, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: CatCatcher/Delete
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var catCatcher = await svc.Get(ApiMessenger.CatCatcher, exEmail, (int)id);
                
                return View(catCatcher);
            }
        }
        //POST: CatCatcher/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatCatcherService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.CatCatcher, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
    }
}