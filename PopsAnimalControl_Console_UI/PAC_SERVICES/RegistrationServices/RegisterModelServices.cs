using PopsAnimalControl_Console_UI.Repositories.RegisterModelRepo;
using PopsAnimalControl_Console_UI.ViewModels.RegisterBindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopsAnimalControl_Console_UI.PAC_SERVICES.RegistrationServices
{
    public class RegisterModelServices
    {
        private RegisterModelRepository _repo;
        public RegisterModelServices()
        {
            _repo = new RegisterModelRepository();
        }
        public async Task<bool> Post(RegisterBindingModel model,string url)
        {
            var success = await _repo.Post(model, url);
            if (success)
            {
                return true;
            }
            return false;
        }


    }
}
