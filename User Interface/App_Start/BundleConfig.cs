using System.Web;
using System.Web.Optimization;

namespace User_Interface
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Content/Themes/assets/global/scripts/datatable.min.js",
                       "~/Content/Themes/assets/global/scripts/datatable.js",
                       "~/Content/Themes/assets/global/scripts/app.min.js",
                       "~/Content/Themes/assets/global/scripts/app.js",
                       "~/Content/Themes/assets/global/plugins/bootstrap/js/bootstrap.js",
                       "~/Content/Themes/assets/global/scripts/Jquery.js"


                       ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Themes/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                    "~/Content/Themes/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                    "~/Content/Themes/assets/global/plugins/bootstrap/css/bootstrap.min.css" ,
                    "~/Content/Themes/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                    "~/Content/Themes/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                    "~/Content/Themes/assets/global/plugins/morris/morris.css" ,
                    "~/Content/Themes/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                    "~/Content/Themes/assets/global/plugins/jqvmap/jqvmap/jqvmap.css",
                    "~/Content/Themes/assets/global/css/components.min.css",
                    "~/Content/Themes/assets/global/css/plugins.min.css",
                    "~/Content/Themes/assets/layouts/layout2/css/layout.min.css",
                    "~/Content/Themes/assets/layouts/layout2/css/themes/blue.min.css",
                    "~/Content/Themes/assets/layouts/layout2/css/custom.min.css",
                    "~/Content/Themes/assets/global/plugins/bootstrap/css/bootstrap.css",
                    "~/Content/Themes/assets/global/plugins/bootstrap/css/bootstrap.min.css"
                    ));
        }
    }
}
