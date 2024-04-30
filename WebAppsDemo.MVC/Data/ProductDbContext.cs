using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppsDemo.MVC.Entities;

namespace WebAppsDemo.MVC.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext (DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppsDemo.MVC.Entities.ProductEntity> ProductEntity { get; set; } = default!;
    }
}
