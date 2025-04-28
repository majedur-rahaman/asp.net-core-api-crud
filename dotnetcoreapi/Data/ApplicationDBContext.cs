using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetcoreapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnetcoreapi.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Many to many relationship
            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.Portfolios)
            .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
           .HasOne(u => u.Stock)
           .WithMany(u => u.Portfolios)
           .HasForeignKey(p => p.StockId);

            //IdentityRole Seed Data
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole {
                    Name="Admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole {
                    Name="User",
                    NormalizedName="USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}