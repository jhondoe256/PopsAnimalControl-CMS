using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.ViewModels.PositionViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.PositionServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Position_Controller
{
    public class PositionController : Controller
    {
        private Guid userID;
        private PositionService CreatePositionService()
        {
            userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new PositionService();
            return svc;
        }
        // GET: Position
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var positions = await svc.Get(ApiMessenger.Position, extEmail);
                return View(positions);
            }
        }
        //GET: Position/{id}
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var position = await svc.Get(ApiMessenger.Position, extEmail, id);
                return View(position);
            }
        }
        //GET: Position/Create/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PositionCreate position)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var svc = CreatePositionService();
                    var user = ctx.Users.Find(userID.ToString());
                    var extEmail = Extraction.ExtractEmail(user.Email);
                    var success = await svc.Post(ApiMessenger.Position, extEmail, position);
                    if (success)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(ModelState);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var position = await svc.Get(ApiMessenger.Position, extEmail, id);
                var posConversion = new PositionEdit
                {
                    PositionID = position.PositionID,
                    Name = position.Name,
                    AvailablePositionCount = position.AvailablePositionCount,
                    DepartmentID = position.DepartmentID
                };
                return View(posConversion);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PositionEdit position, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.PositionUpdate, extEmail, position, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var position = await svc.Get(ApiMessenger.Position, extEmail, (int)id);
                return View(position);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreatePositionService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = Extraction.ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.PositionDelete, extEmail, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(ModelState);
        }
    }
}