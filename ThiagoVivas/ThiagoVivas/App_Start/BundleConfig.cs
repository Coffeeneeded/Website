using System.Web;
using System.Web.Optimization;

namespace TVPresentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Interface")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .Include("~/Scripts/InterfaceCore.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                      "~/Scripts/Angular/angular.min.js",
                      "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                      "~/Scripts/Bootstrap/bootstrap.min.js",
                      "~/Scripts/Bootstrap/jquery-1.9.0.min.js",
                      "~/Scripts/Angular/angular-route.min.js"));


        }
    }
}
