using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdventureWorks.Web.Diag
{
    [RouteArea("")]
    public class DiagController : Controller
    {
        [Route("Diag/Routes")]
        public ActionResult Routes()
        {
            var sb = new StringBuilder();
            using (RouteTable.Routes.GetReadLock())
            {
                foreach (var routeBase in RouteTable.Routes)
                {

                    sb.AppendLine(routeBase.ToString().Replace("System.Web.", "[SW]."));
                    Route route = routeBase as Route;
                    if (route != null)
                    {
                        var url = route.Url;
                        sb.AppendLine("\tUrl=" + url);
                        var defaults = FormatRouteValueDictionary(route.Defaults);
                        sb.AppendLine("\tDefaults=" + defaults);
                        var constraints = FormatRouteValueDictionary(route.Constraints);
                        sb.AppendLine("\tConstraints=" + constraints);
                        var dataTokens = FormatRouteValueDictionary(route.DataTokens);
                        sb.AppendLine("\tDataTokens=" + dataTokens);
                    }
                }
            }
            return Content(sb.ToString(), "text/plain");
        }

        private static string FormatRouteValueDictionary(RouteValueDictionary values)
        {
            if (values == null || values.Count == 0)
                return "(null)";

            string display = string.Empty;
            foreach (string key in values.Keys)
                display += string.Format("{0} = {1}, ", key, values[key]);
            if (display.EndsWith(", "))
                display = display.Substring(0, display.Length - 2);
            return display;
        }
    }
}