﻿using System.Web;
using System.Web.Optimization;

namespace SlotMachine
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                         "~/scripts/jquery.js",
                    
                        "~/scripts/ezslots.js",
                        "~/Scripts/MySlotCommands.js",

                        "~/Scripts/gridmvc.min.js",

                        "~/Scripts/jquery-ui.js"

                       ));

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
                      "~/Content/ezslots.css",       
                      
                      "~/Content/jquery-ui.theme.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/Gridmvc.css",

                      "~/Content/site.css"));
        }
    }
}
