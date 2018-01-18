﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalesWebsite.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
            });

            builder.Entity<ApplicationRole>(entity => {
                entity.Property(m => m.Name).HasMaxLength(127);
                entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Temp> Temps { get; set; }
    }
}