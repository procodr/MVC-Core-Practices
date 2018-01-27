using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Session2.Infrastructure
{
    public class ConfigToResponseHeader
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ConfigToResponseHeader(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-Powered-By", _configuration.GetSection("ResponseHeaders")["X-Powered-By"]);
            httpContext.Response.Headers.Add("H1", _configuration.GetSection("ResponseHeaders")["H1"]);
            httpContext.Response.Headers.Add("H2", _configuration.GetSection("ResponseHeaders")["H2"]);

            await httpContext.Response.WriteAsync("Hello from ConfigToResponseHeader\nResponse Editing Middleware:)");
        }
    }
}
