using System.Web;
using System.Web.Optimization;

namespace AgentPlanner.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/bower_components/jquery/dist/jquery.min.js")
                .Include("~/Scripts/bower_components/moment/moment.js")
                .Include("~/Scripts/bower_components/bootstrap-daterangepicker/daterangepicker.js")
                .Include("~/Scripts/bower_components/sweetAlert/sweet-alert.min.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Scripts/bower_components/angular-block-ui/dist/angular-block-ui.min.css")
                .Include("~/Content/font-awesome/css/font-awesome.min.css")
                .Include("~/Scripts/bower_components/angular-ui-notification/dist/angular-ui-notification.min.css")
                .Include("~/Content/bootstrap-paper.min.css")
                .Include("~/Content/site.css")
                .Include("~/Content/daterangepicker.css")
                .Include("~/Content/ng-table.min.css")
                .Include("~/Scripts/bower_components/angular-ui-select/dist/select.min.css")
                .Include("~/Content/select2.css")
                .Include("~/Content/sweet-alert.css")
                .Include("~/Scripts/bower_components/fullcalendar/dist/fullcalendar.css")
                      );

            bundles.Add(new ScriptBundle("~/angular")
                .Include("~/Scripts/bower_components/angular/angular.min.js")
                .Include("~/Scripts/bower_components/angular-sanitize/angular-sanitize.min.js")
                .Include("~/Scripts/bower_components/angular-ui-router/dist/angular-ui-router.min.js")
                .Include("~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js")
                .Include("~/Scripts/bower_components/angular-block-ui/dist/angular-block-ui.min.js")
                .Include("~/Scripts/bower_components/angular-ui-notification/dist/angular-ui-notification.min.js")
                .Include("~/Scripts/bower_components/ngStorage/ngStorage.min.js")
                .Include("~/Scripts/bower_components/angular-translate/angular-translate.min.js")
                .Include("~/Scripts/bower_components/angular-daterangepicker/js/angular-daterangepicker.js")
                .Include("~/Scripts/bower_components/angular-file-upload/dist/angular-file-upload.min.js")
                .Include("~/Scripts/ng-table.min.js")
                .Include("~/Scripts/bower_components/sweetAlert/SweetAlert.js").
                Include("~/Scripts/bower_components/angular-ui-select/dist/select.min.js")
                .Include("~/Scripts/bower_components/angular-ui-calendar/src/calendar.js")
                .Include("~/Scripts/bower_components/fullcalendar/dist/fullcalendar.js")
                .Include("~/Scripts/bower_components/fullcalendar/dist/gcal.js")
                .Include("~/Scripts/bower_components/angular-ui-validate/dist/validate.min.js")
                );



            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/App/app.js")
                .IncludeDirectory("~/App/Translations/", "*.js", true)
                .IncludeDirectory("~/App/Config/", "*.js", true)
                .IncludeDirectory("~/App/Routes/", "*.js", true)
                .IncludeDirectory("~/App/Controllers/", "*.js", true)
                .IncludeDirectory("~/App/Services/", "*.js", true)
                );

            //BundleTable.EnableOptimizations = false;
        }
    }
}
