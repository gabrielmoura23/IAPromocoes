using System.Web;
using System.Web.Mvc;

namespace IAPromocoes.UI.MVC.Adm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
