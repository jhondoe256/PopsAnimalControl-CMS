using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.ApplicantVieModels;
using PopsAnimalControl_MVC.PAC_SERVICES.ApplicantServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Applicant_Controller.MyHub
{
    public class MyHUBController : Controller
    {
        //private Guid user;
        private ApplicantService CreateApplicantService()
        {
            // var user= Guid.Parse(User.Identity.GetUserId());
            var svc = new ApplicantService();
            return svc;
        }
        // GET: MyHUB
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> MyInfo()
        {
            var userGuid = Guid.Parse(User.Identity.GetUserId());
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.SingleOrDefault(u => u.Id == userGuid.ToString());
                var emailPrefix = CreateEmailPrefix(user.Email);

                if (user is null)
                {
                    return null;
                }
                var svc = CreateApplicantService();
                var applicantInfo = await svc.GetApplicantByEmail(ApiMessenger.ApplicantInfo, emailPrefix);
                return View(applicantInfo);
            }

        }  //MyApplicationInfo
        [HttpGet]
        public async Task<ActionResult> EditApplication()
        {
            var userGuid = Guid.Parse(User.Identity.GetUserId());
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.SingleOrDefault(u => u.Id == userGuid.ToString());
                var emailPrefix = CreateEmailPrefix(user.Email);

                if (user is null)
                {
                    return null;
                }
                var svc = CreateApplicantService();
                var applicantInfo = await svc.GetApplicantByEmail(ApiMessenger.ApplicantUpdate, emailPrefix);
                return View(applicantInfo);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditApplication(ApplicantEdit applicant)
        {
           
                var userGuid = Guid.Parse(User.Identity.GetUserId());
                using (var ctx = new ApplicationDbContext())
                {
                    var user = ctx.Users.SingleOrDefault(u => u.Id == userGuid.ToString());
                    var emailPrefix = CreateEmailPrefix(user.Email);

                    if (user is null)
                    {
                        return null;
                    }
                    var svc = CreateApplicantService();
                    var isSuccessful = await svc.UpdateApplicantViaEmail(ApiMessenger.ApplicantUpdate, emailPrefix, applicant);
                    if (isSuccessful)
                    {
                        return RedirectToAction("Index");
                    }
                }
            
            return View(ModelState);
        }
        private string CreateEmailPrefix(string email)
        {
            string emailPrefix = "";
            foreach (var item in email)
            {
                if (item != '@')
                {
                    emailPrefix += item;
                }
                if (item == '@')
                {
                    return emailPrefix;
                }

            }
            return null;
        }
    }
}