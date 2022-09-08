using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PopsAnimalControl_MVC.Startup))]
namespace PopsAnimalControl_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
