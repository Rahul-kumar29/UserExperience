using BlazorWebAssemblyCrudDotNet8.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BlazorWebAssemblyCrudDotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Detail>().HasData(
                new Detail { Id = 1, Username = "user1", Name = "User One", Email = "user1@example.com", PasswordHash = "hashedPassword", Photo = null },
                new Detail { Id = 2, Username = "user2", Name = "User Two", Email = "user2@example.com", PasswordHash = "hashedPassword", Photo = null }
            ); 
        }

        public DbSet<Detail> Details { get; set; }
    }
}
