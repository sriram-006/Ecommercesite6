using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using truyum_WebAPIPracticeCheck.Models;

namespace truyum_WebAPIPracticeCheck.Models
{
    public class TruYumContext : DbContext
    {
        public TruYumContext(DbContextOptions<TruYumContext> options) : base(options)
        {
            //Empty constructor….
        }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
            modelBuilder.Entity<User>().ToTable("Users");
          

        }
        public DbSet<User> Users { get; set; }

    }
}
