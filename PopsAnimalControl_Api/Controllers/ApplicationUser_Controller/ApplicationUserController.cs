using Microsoft.AspNet.Identity;
using PAC.Services.ApplicationUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PopsAnimalControl_Api.Controllers.ApplicationUser_Controller
{
    public class ApplicationUserController : ApiController
    {
        private ApplcationUserService CreateAUS()
        {
            var svc = new ApplcationUserService();
            return svc;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateAUS();
            var users = await svc.Get();
            return Ok(users);
        }
    }
}
