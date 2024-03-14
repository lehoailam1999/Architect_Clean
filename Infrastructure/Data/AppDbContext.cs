using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //{
        //}

        //public AppDbContext(DbContextOptions options) : base(options)
        //{   
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<PropertyDetail> PropertyDetails { get; set; }
        public DbSet<VariantProperty> VariantProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5K7OTPS\\SQLEXPRESS;Initial Catalog=CleanArchitecture1;Integrated Security=True;Encrypt=true;Trustservercertificate=true;");
        }
    }
}
