using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace AspOnePage
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            #region Angular material

            bundles.Add(new ScriptBundle("~/bundles/material-scripts").Include(
                "~/Scripts/angular/angular.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/Luxtour/lt-angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-touch.min.js",
                "~/Scripts/angular-animate/angular-animate.js",
                "~/Scripts/angular-messages.js",
                "~/Scripts/angular-aria/angular-aria.js",
                "~/Scripts/angular-material/angular-material.js",
                "~/Scripts/angular-carousel.min.js",
                "~/Scripts/SmoothScroll.min.js",
                "~/Scripts/ltConfig.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/material-scripts.min").Include(
                "~/Scripts/angular/angular.min.js",
                "~/Scripts/Luxtour/lt-angular.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-touch.min.js",
                "~/Scripts/angular-animate/angular-animate.min.js",
                "~/Scripts/angular-messages.min.js",
                "~/Scripts/angular-aria/angular-aria.min.js",
                "~/Scripts/angular-carousel.min.js",
                "~/Scripts/angular-material/angular-material.min.js",
                "~/Scripts/SmoothScroll.min.js",
                "~/Scripts/ltConfig.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/main-app").Include(
                "~/Scripts/AppMain/MainApp.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/material-style").Include(
                "~/Content/material-fonts.css",
                "~/Content/material-icons.css",
                "~/Content/angular-material.css",
                "~/Content/angular-carousel.min.css",
                "~/Content/Site.css"
                ));

            #endregion



            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.css",
                 "~/Content/Site.css"));
        }
    }
}
