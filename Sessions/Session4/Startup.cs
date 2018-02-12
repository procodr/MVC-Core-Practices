using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Session4.Infrustructures;

namespace Session4
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var router = new OldUrlRouter();
            var routes = new RouteBuilder(app);
            routes.DefaultHandler = new OldUrlRouter();
            app.UseRouter(routes.Build());
            //app.UseMvc(
            //    route =>
            //    {
            //        route.MapRoute("",);
            //    }
            //);
        }
    }
}
