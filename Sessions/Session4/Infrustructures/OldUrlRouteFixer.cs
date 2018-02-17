using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Infrustructures
{
    public class OldUrlRouteFixer
    {
        private IRouter _router;
        public OldUrlRouteFixer(IRouter router)
        {
            _router = router;
        }
        public Task FixRoute(HttpContext httpContext)
        {
            var path = httpContext.Request.Path.Value;
            var routeContext = new RouteContext(httpContext)
            {
                RouteData = httpContext.GetRouteData()
            };

            routeContext.RouteData.Values["controller"] = "Home";
            routeContext.RouteData.Values["action"] = "Index";

            return _router.RouteAsync(routeContext);
        }
    }
}
