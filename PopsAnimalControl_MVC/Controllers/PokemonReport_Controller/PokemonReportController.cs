using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.PokemonReportViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.PokemonReportServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.PokemonReport_Controller
{
    public class PokemonReportController : Controller
    {
        private Guid userID;
        private PokemonReportService CreatePRS()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new PokemonReportService();
            return svc;
        }
        // GET: PokemonReport
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePRS();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var reports = await svc.Get(ApiMessenger.PokemonReport, exEmail);
                return View(reports);
            }
        }
        //GET: PokemonReport/Details
        public async Task<ActionResult> Details(int id)
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var svc = CreatePRS();
                    var user = ctx.Users.Find(userID.ToString());
                    var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                    var reports = await svc.Get(ApiMessenger.PokemonReport, exEmail,id);
                    return View(reports);
                }
        }
        //GET: PokemonReport/Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: PokemonReport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PokemonReportCreate pokemonReportCreate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePRS();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.PokemonReport, exEmail, pokemonReportCreate);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        //GET: PokemonReport/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePRS();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var reports = await svc.Get(ApiMessenger.PokemonReport, exEmail, id);
                var conversion = new PokemonReportEdit
                {
                    Age = reports.Age,
                    CaptureWorth = reports.CaptureWorth,
                    CreationDate = reports.CreationDate,
                    DateOfBirth = reports.DateOfBirth,
                    DateOfCapture = reports.DateOfCapture,
                    EmployeeID = reports.EmployeeID,
                    EventDescription = reports.EventDescription,
                    FirstName = reports.FirstName,
                    HasChipIdentification = reports.HasChipIdentification,
                    HasCollarIdentification = reports.HasCollarIdentification,
                    InjurySeverityType = reports.InjurySeverityType,
                    LastName = reports.LastName,
                    ModificationionDate = DateTime.Now,
                    name = reports.name,
                    PokemonBirthName=reports.PokemonBirthName,
                    ReportID=reports.ReportID,
                    TempermentType=reports.TempermentType,
                };
                return View(conversion);
            }
        }
        //POST: PokemonReport/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PokemonReportEdit pokemonReport, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePRS();
                var user = ctx.Users.Find(userID.ToString());
                var exEmail = Utilities.Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.PokemonReport, exEmail, pokemonReport,id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}