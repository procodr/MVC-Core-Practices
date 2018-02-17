using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session4.Models
{
    public static class DbInitializer
    {
        public static void Initialize (DevDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.UrlMaps.Any()) return;

            var UrlMaps = new UrlMap[]
            {
                new UrlMap{Url="index.aspx", Controller="Home", Action="Index"},
                new UrlMap{Url="index2.aspx", Controller="Home", Action="Index2"},
                new UrlMap{Url="index3.aspx", Controller="Home", Action="Index3"},
                new UrlMap{Url="index4.aspx", Controller="Home", Action="Index4"}
            };

            foreach (var item in UrlMaps) context.UrlMaps.Add(item);

            context.SaveChanges();
        }
    }
}
