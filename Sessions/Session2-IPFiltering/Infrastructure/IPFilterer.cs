using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace Session2_IPFiltering.Infrastructure
{
    public class IPFilterer
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public IPFilterer(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            IPNetwork ipNetwork;
            if (httpContext.Connection.RemoteIpAddress.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                ipNetwork = IPNetwork.Parse(_configuration.GetSection("AllowedIPs")["v4"]);
            else
                ipNetwork = IPNetwork.Parse(_configuration.GetSection("AllowedIPs")["v6"]);

            if (IPNetwork.Contains(ipNetwork, httpContext.Connection.RemoteIpAddress))
            {
                await _next.Invoke(httpContext);
            }
            else
            {
                httpContext.Response.StatusCode = 403;
            }
        }
    }
}
