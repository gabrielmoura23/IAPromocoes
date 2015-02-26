using IAPromocoes.UI.MVC.Adm.App_Start;
using System.Web;
using System.Web.Optimization;

namespace IAPromocoes.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            var coreplugins = new ScriptBundle("~/bundles/coreplugins")
            .Include("~/assets/global/plugins/jquery.min.js")
            .Include("~/assets/global/plugins/jquery-migrate.min.js")
            .Include("~/assets/global/plugins/bootstrap/js/bootstrap.min.js")
            .Include("~/assets/frontend/layout/scripts/back-to-top.js");
            coreplugins.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(coreplugins);

            //var corepluginsinterno = new ScriptBundle("~/bundles/corepluginsinterno")
            //.Include("~/assets/global/plugins/jquery.min.js")
            //.Include("~/assets/global/plugins/jquery-migrate.min.js")
            //.Include("~/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js")
            //.Include("~/assets/global/plugins/bootstrap/js/bootstrap.min.js")
            //.Include("~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js")
            //.Include("~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js")
            //.Include("~/assets/global/plugins/jquery.blockui.min.js")
            //.Include("~/assets/global/plugins/jquery.cokie.min.js")
            //.Include("~/assets/global/plugins/uniform/jquery.uniform.min.js");
            //corepluginsinterno.Orderer = new NonOrderingBundleOrderer();
            //bundles.Add(corepluginsinterno);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            var globalstyles = new StyleBundle("~/Content/globalstyles")
            .Include("~/assets/global/plugins/font-awesome/css/font-awesome.min.css")
            .Include("~/assets/global/plugins/bootstrap/css/bootstrap.min.css");
            globalstyles.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(globalstyles);

            var themestyles = new StyleBundle("~/Content/themestyles")
            .Include("~/assets/global/css/components.css")
            .Include("~/assets/frontend/layout/css/style.css")
            .Include("~/assets/frontend/pages/css/style-revolution-slider.css")
            .Include("~/assets/frontend/layout/css/style-responsive.css")
            .Include("~/assets/frontend/layout/css/themes/red.css")
            .Include("~/assets/frontend/layout/css/custom.css");
            themestyles.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(themestyles);


            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            var jqueryval = new ScriptBundle("~/bundles/jqueryval")
            .Include("~/Scripts/jquery.validate.min.js")
            .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
            .Include("~/Scripts/globalize/globalize.js")
            .Include("~/Scripts/globalize/cultures/globalize.culture.pt-BR.js")
            .Include("~/Scripts/jquery.validate.globalize.js");
            jqueryval.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(jqueryval);

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            #if !DEBUG
                BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}
