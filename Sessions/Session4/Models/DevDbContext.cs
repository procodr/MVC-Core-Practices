using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public class DevDbContext : DbContext
    {
        public DevDbContext(DbContextOptions<DevDbContext> options) : base(options)
        {

        }
        public DbSet<UrlMap> UrlMaps { get; set; }
    }
}
