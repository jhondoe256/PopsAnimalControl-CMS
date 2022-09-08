using Microsoft.AspNet.Identity.EntityFramework;
using PAC.Models.ApplicationUserModels.ApplicaitonUser_RoleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Models.ApplicationUserModels
{
    public class ApplicationUserListItem
    {
        public string Email { get; set; }
        public ICollection<IdentityUserRole> Roles { get; set; } = new List<IdentityUserRole>();
        public List<string> RoleNames = new List<string>();
    }
}
