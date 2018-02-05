using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Session2_IPFiltering.Infrastructure;

namespace Session2_IPFiltering
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IConfiguration _configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(_configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<IPFilterer>();
            app.Run((httpContext) =>
            {
                return httpContext.Response.WriteAsync("Congratulations! You have passed my little inApp Firewall :)");
            });
        }
    }
}
