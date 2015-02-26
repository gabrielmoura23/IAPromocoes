using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IAPromocoes.UI.MVC.Adm;

[assembly: OwinStartup("StartupAdm", typeof(StartupAdm))]

namespace IAPromocoes.UI.MVC.Adm
{
    public partial class StartupAdm
    {
        public static void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth2(app);
        }
    }
}
