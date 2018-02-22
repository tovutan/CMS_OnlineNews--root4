using System.Web;
using System.Web.Optimization;

namespace CMS_OnlineNews
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
                      "~/Content/site1.css",
                       "~/Content/reset.css",
                      "~/Content/header-footer.css",
                      "~/Content/news.css"
                      ));


            //thêm vào

            bundles.Add(new StyleBundle("~/Content/css/Mobile").Include(
                      "~/Content/reset.css",
                      "~/Content/swiper.min.css",
                      "~/Content/carousel.bootstrap.css",
                      "~/Content/header-footer.mobile.css",
                      "~/Content/news.mobile.css"));

            bundles.Add(new StyleBundle("~/bundles/cssadminlte").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/ionicons.min.css",
                        "~/Content/bootstrap-datepicker.min.css",
                        "~/Content/select2.min.css",
                        //"~/Content/bootstrap-tagsinput.css",
                        //"~/Content/bootstrap-tagsinput-app.css",
                        //"~/Plugins/iCheck/all.css",
                        //"~/Plugins/kendo-ui/styles/kendo.common-material.min.css",
                        //"~/Plugins/kendo-ui/styles/kendo.material.min.css",
                        //"~/Plugins/kendo-ui/styles/kendo.material.mobile.min.css",
                        "~/Content/AdminLTE.min.css",
                        "~/Content/skin-blue.min.css",
                        "~/Content/Admin.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                       "~/Scripts/libs/jquery-3.2.0.min.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/select2.full.min.js",
                       "~/Scripts/libs/jquery.slimscroll.min.js"
                       //"~/Scripts/libs/bootstrap-tagsinput.min.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/libs/jquery-3.2.0.min.js",
                        "~/Scripts/libs/ie-emulation-modes-warning.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/script/Login").Include(
                        "~/Scripts/libs/jquery-3.2.0.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Plugins/iCheck/icheck.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/script/Mobile").Include(
                        "~/Scripts/libs/jquery-3.2.0.min.js",
                        "~/Scripts/libs/swiper.min.js",
                        "~/Scripts/libs/carousel.bootstrap.min.js",
                        "~/Scripts/news.mobile.js",
                        "~/Scripts/header-footer.mobile.js",
                        "~/Scripts/libs/ie-emulation-modes-warning.js"
                        ));
        }
    }
}
