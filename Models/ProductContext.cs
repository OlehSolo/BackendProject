using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPayAspNetCoreWebApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions contextOptions):base(contextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
         
}
