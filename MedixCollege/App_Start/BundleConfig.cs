using System.Web;
using System.Web.Optimization;

namespace MedixCollege
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/mediaelement-and-player.min.js",
                      "~/Scripts/jquery.mousewheel.min.js",
                      "~/Scripts/jquery.smoothdivscroll-1.3-min.js",
                      "~/Scripts/jquery.flexisel.js",
                      "~/Scripts/responsiveslides.min.js",
                      "~/Scripts/bootstrap.youtubepopup.min.js",
                      "~/Scripts/parsley.min.js",
                      "~/Scripts/jquery.blockUI.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/mediaelementplayer.min.css",
                      "~/Content/smoothDivScroll.css",
                      "~/Content/responsiveslides.css"));
        }
    }
}
