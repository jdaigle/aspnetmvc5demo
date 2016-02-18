using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using AdventureWorks.Web.Infrastructure;
using StackExchange.Profiling;
using StackExchange.Profiling.Mvc;

namespace AdventureWorks.Web
{
    public static class Startup
    {
        public static void ApplicationStart()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Clear();
            var engine = new ViewModelSpecifiedViewEngine();
            ViewEngines.Engines.Insert(0, engine);
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);

            SetupMiniProfiler();
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("assets/{*pathInfo}");
            ///routes.IgnoreRoute("StoreFront/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.MapMvcAttributeRoutes();
            routes.LowercaseUrls = true;

            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }

        private static void SetupMiniProfiler()
        {
            MiniProfiler.Settings.IgnoredPaths = new[]
            {
                "/assets",
                "/favicon.ico",
                "/elmah.axd",
            };
            var copy = ViewEngines.Engines.ToList();
            ViewEngines.Engines.Clear();
            foreach (var item in copy)
            {
                ViewEngines.Engines.Add(new ProfilingViewEngine(item));
            }
        }
    }
}