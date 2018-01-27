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
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigToResponseHeader(RequestDelegate next, IConfigurationRoot configurationRoot)
        {
            _next = next;
            _configurationRoot = configurationRoot;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("X-Powered-By", _configurationRoot.GetSection("ResponseHeaders")["X-Powered-By"]);
            httpContext.Response.Headers.Add("H1", _configurationRoot.GetSection("ResponseHeaders")["H1"]);
            httpContext.Response.Headers.Add("H2", _configurationRoot.GetSection("ResponseHeaders")["H2"]);

            await httpContext.Response.WriteAsync("Hello from ConfigToResponseHeader\nResponse Editing Middleware:)");
        }
    }
}
