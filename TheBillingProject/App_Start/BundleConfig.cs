using System.Web;
using System.Web.Optimization;

namespace TheBillingProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/assets/libs/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                      "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                      "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/libs/popper.js/dist/umd/popper.min.js",
                      "~/assets/libs/bootstrap/dist/js/bootstrap.min.js",
                      "~/assets/libs/perfect-scrollbar/dist/perfect-scrollbar.jquery.min.js",
                      "~/assets/extra-libs/sparkline/sparkline.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/dist/css/style.min.css"));
        }
    }
}
