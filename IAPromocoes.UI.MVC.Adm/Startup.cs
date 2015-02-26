using IAPromocoes.UI.MVC.Adm;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("Startup", typeof(Startup))]
namespace IAPromocoes.UI.MVC.Adm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            StartupAdm.Configuration(app);
        }
    }
}