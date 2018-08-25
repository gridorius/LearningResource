using System.Web;
using System.Web.Optimization;

namespace patternsLearning
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*
            bundles.Add(new ScriptBundle("~/bundles/name").Include(
                        "~/Scripts/name.js"));

            bundles.Add(new StyleBundle("~/Content/name").Include(
                      "~/Content/name.css");
            */

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/Scripts/vue.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                        "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/patterns").Include(
                        "~/Scripts/patterns.js"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/home.js"));

            bundles.Add(new StyleBundle("~/Content/main").Include(
                      "~/Content/main.css"));

            bundles.Add(new StyleBundle("~/Content/patterns").Include(
                        "~/Content/patterns.css"));

            bundles.Add(new StyleBundle("~/Content/home").Include(
                        "~/Content/home.css"));
        }
    }
}
