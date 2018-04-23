using System.Web;
using System.Web.Optimization;

namespace Basic
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //bundles.Add(new StyleBundle("~/assets/css").Include(
            //          "~/assets/css/icons/icomoon/styles.css",
            //          "~/assets/css/components.css",
            //          "~/assets/css/colors.css",
            //          "~/assets/css/extras/animate.min.css",
            //          "~/assets/css/core.css"));
            //bundles.Add(new ScriptBundle("~/assets/js").Include(
            //        "~/assets/js/plugins/loaders/pace.min.js",
            //        "~/assets/js/plugins/loaders/blockui.min.js",
            //        "~/assets/js/core/app.js"
            //    ));
        }
    }
}
