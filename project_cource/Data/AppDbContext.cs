﻿using Microsoft.EntityFrameworkCore;
using project_cource.Models;

namespace project_cource.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category() { Id = 1, Name = "Select item category, Please!." },
                new Category() { Id = 2, Name = "Mobiles" },
                new Category() { Id = 3, Name = "Computers" },
                new Category() { Id = 4, Name = "Electice Machiens" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
