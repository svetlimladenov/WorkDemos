using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WebApi.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)  
            : base(options)
        { 
        }

        public virtual DbSet<Credit> Credit { get; set; }

        public virtual DbSet<CreditStatus> CreditStatus { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<ProductType> ProductType { get; set; }

        public virtual DbSet<ShoppingItem> ShoppingItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credit>()
                 .Property(c => c.Limit)
                 .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ShoppingItem>()
                 .Property(c => c.Price)
                 .HasColumnType("decimal(5,2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=WebApiForTests;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
