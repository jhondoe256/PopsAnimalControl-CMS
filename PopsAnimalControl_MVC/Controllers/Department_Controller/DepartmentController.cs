using Microsoft.AspNet.Identity;
using PopsAnimalControl_MVC.Models;
using PopsAnimalControl_MVC.Models.DataModels.DepartmentData;
using PopsAnimalControl_MVC.Models.ViewModels.DepartmentViewModels;
using PopsAnimalControl_MVC.PAC_SERVICES.DepartmentServices;
using PopsAnimalControl_MVC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PopsAnimalControl_MVC.Controllers.Department_Controller
{
    public class DepartmentController : Controller
    {
        private Guid userID;

        private DepartmentService CreateDepartmentService()
        {
            userID= Guid.Parse(User.Identity.GetUserId());
            var svc = new DepartmentService();
            return svc;
        }
        // GET: Department
        public async Task<ActionResult> Index()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                
                var extEmail= ExtractEmail(user.Email);
                var departments = await svc.Get(ApiMessenger.Department,extEmail);
                return View(departments);
            }
            
        }
        //GET: Department/Detail
        public async Task<ActionResult> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var department = await svc.Get(ApiMessenger.Department, extEmail, id);
                return View(department);
            }
        }
        //GET: Department/Create
        public ActionResult Create() 
        {
            return View();
        }
        //POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DepartmentCreate department)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var success = await svc.Post(ApiMessenger.DepartmentCreate, extEmail, department);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
        }
        //GET: Department/Edit
        public async Task<ActionResult> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var department = await svc.Get(ApiMessenger.Department, extEmail, id);
                var conversion = new DepartmentEdit
                {
                    ID=department.ID,
                    Name=department.Name,
                };
                return View(conversion);
            }
        }
        //POST: Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DepartmentEdit department, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var success = await svc.Put(ApiMessenger.DepartmentUpdate, extEmail,department, id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int? id) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var department = await svc.Get(ApiMessenger.Department, extEmail, (int)id);
                return View(department);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = CreateDepartmentService();
                var user = ctx.Users.Find(userID.ToString());
                var extEmail = ExtractEmail(user.Email);
                var success = await svc.Delete(ApiMessenger.Department, extEmail,id);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                return View(ModelState);
            }
        }
        private string ExtractEmail(string email)
        {
            var extractedEmail = "";
            foreach (var item in email)
            {
                if (item != '@')
                {
                    extractedEmail += item;
                }
                else
                {
                    return extractedEmail;
                }
            }
            return null;
        }
    }
}