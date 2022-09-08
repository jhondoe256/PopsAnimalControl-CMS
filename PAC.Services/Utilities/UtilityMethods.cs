using PopsAnimalControl.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAC.Services.Utilities
{
    public static class UtilityMethods
    {
        public static Guid GetGuid(string email)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var users =  ctx.Applicants.ToList();
                
                foreach (var item in users)
                {
                    if (item.EmailAddress.Contains(email))
                    {
                        var userGuid = item.OwnerID;
                        return userGuid;
                    }
                }
            }
            return default;
        }

    }
}
