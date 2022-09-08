using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.CatReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.CatReportServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.CatReport_Controller
{
    public class CatReportController : Controller
    {
        private Guid userID;
        private CatReportService CreateCatReportService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CatReportService();
            return svc;
        }
        // GET: CatReport
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var reports = await svc.Get(ApiMessenger.CatReport,exEmail);
                return View(reports);
            }
        }
        //GET: CatReport/Details
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var report = await svc.Get(ApiMessenger.CatReport, exEmail,id);
                return View(report);
            }
        }
        //GET: CatReport/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: CatReport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CatReportCreate catReportCreate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.CatReport, exEmail,catReportCreate);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: CatReport/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var report = await svc.Get(ApiMessenger.CatReport, exEmail, id);
                var conversion = new CatReportEdit
                {
                    
                    CaptureWorth=report.CaptureWorth,
                    CatBreedID=report.CatBreedID,
                    DateOfBirth=report.DateOfBirth,
                    DateOfCapture=report.DateOfCapture,
                    EmployeeID=report.EmployeeID,
                    EventDescription=report.EventDescription,
                    FirstName=report.EmployeeFirstName,
                    LastName=report.EmployeeLastName,
                    HasChipIdentification=report.HasChipIdentification,
                    HasCollarIdentification=report.HasCollarIdentification,
                    ReportID=report.ReportID,
                    InjurySeverityType=report.InjurySeverityType,
                    TempermentType=report.TempermentType,
                    Name=report.Name,
                    ModificationionDate=DateTime.UtcNow,
                };
                return View(conversion);
            }
        }
        //POST: CatReport/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatReportEdit catReport, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateCatReportService();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.CatReport, exEmail, catReport,id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}