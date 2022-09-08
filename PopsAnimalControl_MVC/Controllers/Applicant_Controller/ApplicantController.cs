using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.PAC_SERVICES.ApplicantServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Applicant_Controller
{
    public class ApplicantController : Controller
    {
        private ApplicantService CreateApplicantService()
        {
            //var user = Guid.Parse(User.Identity.GetUserId());
            var svc = new ApplicantService();
            return svc;
        }
        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }
        //POST: Applicant
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicantCreate applicant)
        {
            if (ModelState.IsValid)
            {
                var svc = CreateApplicantService();
                var isSucessful = await svc.CreateApplicant(ApiMessenger.Applicant, applicant);
                if (isSucessful)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(ModelState);
        }
    }
}