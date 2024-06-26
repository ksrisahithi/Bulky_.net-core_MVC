﻿using Microsoft.EntityFrameworkCore;
using Bulky.Models;

namespace Bulky.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Romance", DisplayOrder = 1},
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Fantasy", DisplayOrder = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
