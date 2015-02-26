using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace IAPromocoes.Infra.CrossCutting.Identity.Adm.Configuration
{
    public class ApplicationSignInManager : SignInManager<UsuarioAdm, string>
    {

        public ApplicationSignInManager(UsuarioAdmManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager) { }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<UsuarioAdmManager>(), context.Authentication);
        }
    }
}
