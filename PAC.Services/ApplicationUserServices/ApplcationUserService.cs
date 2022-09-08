using Microsoft.AspNet.Identity.EntityFramework;
using PAC.Models.ApplicationUserModels;
using PAC.Models.ApplicationUserModels.ApplicaitonUser_RoleModels;
using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.ApplicationUserServices
{

    public class ApplcationUserService
    {
        public async Task<IEnumerable<ApplicationUserListItem>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var users =
                    await
                    ctx
                    .Users
                    .Select(u => new ApplicationUserListItem
                    {
                        Email = u.Email,
                        Roles = u.Roles,
                    }).ToListAsync();
                foreach (var item in users)
                {
                    List<string> roleNames = new List<string>();
                    foreach (var i in item.Roles)
                    {
                        var name = ctx.Roles.Find(i.RoleId).Name;
                        if (name != null)
                        {
                            roleNames.Add(name);
                        }
                        item.RoleNames = roleNames;
                    }
                }
                return users;
            }
        }

        public async Task<ApplicationUser> Get(string email)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    await
                    ctx
                    .Users
                    .SingleOrDefaultAsync(u => u.Email == email);
                if (user is null)
                {
                    return null;
                }
                   
                
                return user;
            }
        }
    }
}
