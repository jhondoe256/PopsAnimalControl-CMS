using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.ViewModels.TokenViewModels
{
    public class TokenViewModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
     //   public string Token { get; set; }
    }

    public class TokenReturnedModel 
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
    }
}
