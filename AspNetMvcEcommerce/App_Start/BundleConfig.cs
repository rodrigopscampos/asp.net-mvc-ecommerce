using System.Web.Optimization;

namespace AspNetMvcEcommerce
{
    public class BundleConfig
    {
        public static void RegistraBundlers(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
        }
    }
}