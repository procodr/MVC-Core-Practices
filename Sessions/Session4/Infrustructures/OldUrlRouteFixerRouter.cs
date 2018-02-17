using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Session4.Models;
using System.Threading.Tasks;

namespace Session4.Infrustructures
{
    public class OldUrlRouteFixerRouter : IRouter
    {
        private readonly IApplicationBuilder _app;
        private IRouter _router;
        public OldUrlRouteFixerRouter(IRouter router, IApplicationBuilder app)
        {
            _app = app;
            _router = router;
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public Task RouteAsync(RouteContext context)
        {
            using (var serviceScope = _app.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DevDbContext>();
                foreach (UrlMap urlMap in db.UrlMaps)
                {
                    if (context.HttpContext.Request.Path.Value.ToLower() == urlMap.Url)
                    {
                        context.RouteData.Values["controller"] = urlMap.Controller;
                        context.RouteData.Values["action"] = urlMap.Action;
                    }
                }
            }

            return _router.RouteAsync(context);
        }
    }
}
