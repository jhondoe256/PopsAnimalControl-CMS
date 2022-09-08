using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.PAC_SERVICES.HumanResourcesHubServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.HumanResourcesHUB
{
    public class HumanResourcesHUBController : Controller
    {
        private HumanResourcesHubService CreateHR_HUB_Service()
        {
           // var user = Guid.Parse(User.Identity.GetUserId());
           // var svc = new HumanResourcesHubService(user);
            var svc = new HumanResourcesHubService();
            return svc;
        }
        // GET: HumanResourcesHUB
        public async Task<ActionResult> Index()
        {
            var svc = CreateHR_HUB_Service();
            var applicants = await svc.Get(ApiMessenger.HumanResourcesHUB);
            return View(applicants);
        }
        //GET:HumanResourcesHUB/{id}
        public async Task<ActionResult> Details(int id)
        {
            var svc = CreateHR_HUB_Service();
            var applicant = await svc.Get(ApiMessenger.Applicant,id);
            return View(applicant);
        }
        //GET: HumanResourcesHUB/DogCatcherApplicants
        public async Task<ActionResult> DogCatcherApplicants()
        {
            var svc = CreateHR_HUB_Service();
            var applicants = await svc.Get(ApiMessenger.DogCatcherApplicants);
            return View(applicants);
        }
        //GET: HumanResourcesHUB/CatCatcherApplicants
        public async Task<ActionResult> CatCatcherApplicants()
        {
            var svc = CreateHR_HUB_Service();
            var applicants = await svc.Get(ApiMessenger.CatCatcherApplicants);
            return View(applicants);
        }
        //GET: HumanResourcesHUB/PokemonCatcherApplicants
        public async Task<ActionResult> PokemonCatcherApplicants()
        {
            var svc = CreateHR_HUB_Service();
            var applicants = await svc.Get(ApiMessenger.PokemonCatcherApplicants);
            return View(applicants);
        }
    }
}