using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Session4.Infrustructures;
using Session4.Models;

namespace Session4
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DevDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(
                routeBuilder =>
                {
                    routeBuilder.Routes.Add(
                            new OldUrlRouteFixerRouter(
                                routeBuilder.DefaultHandler,
                                app
                            )
                        );
                    //routeBuilder.MapRoute("{controller=Home}/{action=Index}/{id?}", (new OldUrlRouteFixer(routeBuilder.DefaultHandler)).FixRoute ); //NOT Works.. I dont know why!
                }
            );
        }
    }
}
