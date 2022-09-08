using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.Enums;
using PopsAnimalControl_MVC.Models.ViewModels.CatViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.CatServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Cat_Controller
{
    public class CatController : Controller
    {
        private Guid userID;
        private CatService CreateCatService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatService();
            return svc;
        }

        // GET: Cat
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var cats = await svc.Get(ApiMessenger.Cat, exEmail);
                return View(cats);
            }
        }
        //GET: Cat/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var cat = await svc.Get(ApiMessenger.Cat, exEmail, id);
                return View(cat);
            }
        }
        //GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Cat/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatCreate cat)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.Cat, exEmail, cat);
                if (success)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(ModelState);
        }
        //GET: Cat/Edit
       
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var cat = await svc.Get(ApiMessenger.Cat, exEmail, id);
                var conversion = new CatEdit
                {
                    CaptureWorth=cat.CaptureWorth,
                    DateOfBirth=cat.DateOfBirth,
                    DateOfCapture=cat.DateOfCapture,
                    HasChipIdentification=cat.HasChipIdentification,
                    HasCollarIdentification=cat.HasCollarIdentification,
                    ID=cat.ID,
                    InjurySeverityType=cat.InjurySeverityType,
                    TempermentType=cat.TempermentType,
                    Name=cat.Name,
                    ReportID=cat.CatReport.ReportID,
                };
                return View(conversion);
            }
        }
        //POST: Cat/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatEdit cat, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.Cat, exEmail, cat,id);
                if (success)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(ModelState);
        }
        //GET: Cat/Delete
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var cat = await svc.Get(ApiMessenger.Cat, exEmail, (int)id);
                return View(cat);
            }
        }
        //POST: Cat/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.Cat, exEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}