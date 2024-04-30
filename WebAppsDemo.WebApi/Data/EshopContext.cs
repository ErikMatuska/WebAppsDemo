using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppsDemo.WebApi.Data
{
    public class EshopContext : DbContext
    {
        public EshopContext (DbContextOptions<EshopContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppsDemo.WebApi.Data.CustomerEntity> CustomerEntity { get; set; } = default!;
    }
}
