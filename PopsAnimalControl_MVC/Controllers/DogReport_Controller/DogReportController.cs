using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.Enums;
using PopsAnimalControl_MVC.Models.ViewModels.DogReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.DogReportServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.DogReport_Controller
{
    public class DogReportController : Controller
    {
        private Guid userID;
        private DogReportService CreateDogReportService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new DogReportService();
            return svc;
        }
        // GET: DogReport
        public async Task<ActionResult> Index()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateDogReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var reports = await svc.Get(ApiMessenger.DogReport, exEmail);
                return View(reports);
            }
        }
        //GET: DogReport/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var svc = CreateDogReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var report = await svc.Get(ApiMessenger.DogReport, exEmail, id);
                return View(report);
            }
        }
        //GET: DogReport/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: DogReport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DogReportCreate dogReport)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var succsss = await svc.Post(ApiMessenger.DogReport, exEmail, dogReport);
                if (succsss)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        //GET: DogReport/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDogReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var report = await svc.Get(ApiMessenger.DogReport, exEmail, id);
                var conversion = new DogReportEdit
                {
                    CaptureWorth=report.CaptureWorth,
                    DateOfBirth=report.DateOfBirth,
                    DateOfCapture=report.DateOfCapture,
                    EmployeeID=report.EmployeeID,
                    EventDescription=report.EventDescription,
                    FirstName=report.EmployeeFirstName,
                    LastName=report.EmployeeLastName,
                    HasChipIdentification=report.HasChipIdentification,
                    HasCollarIdentification=report.HasCollarIdentification,
                   // InjurySeverityType= (InjuryServerityType)int.Parse(report.InjurySeverityType),//May need to make UI element...
                  //  TempermentType=(Temperment)int.Parse(report.TempermentType),
                    Name=report.Name,
                    BreedID=report.BreedID,
                    ReportID=report.ReportID,
                    ModificationionDate=DateTime.Now,

                };
                return View(conversion);
            }
        }
        //POST: DogReport/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DogReportEdit dogReport, int id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var svc = CreateDogReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.DogReport, exEmail, dogReport, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        ////GET: DogReport/Delete
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    using (var ctx= new ApplicationDbContext())
        //    {
        //        var svc = CreateDogReportService();
        //        var user = ctx.Users.Find(userID.ToString());
        //        var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
        //        var report = await svc.Get(ApiMessenger.DogReport, exEmail, (int)id);
        //        return View(report);
        //    }
        //}
       

    }
}