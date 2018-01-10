using System.Web;
using System.Web.Optimization;

namespace Task1
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Scripts/bootstrap.js",
                "~/Content/Index.css"));

            bundles.Add(new StyleBundle("~/Guests/css").Include(
                "~/Content/Guests.css"));

            bundles.Add(new StyleBundle("~/Anketa/css").Include(
                "~/Content/Anketa.css"));

            bundles.Add(new StyleBundle("~/Layout/css").Include(
                "~/Content/bootstrap.min.css",
                 "~/Scripts/bootstrap.js",
                "~/Content/bootstrap.css",
                "~/Content/Layout.css"));

        }
    }
}
