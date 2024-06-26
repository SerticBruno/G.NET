﻿using System.Reflection.Metadata;
using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Repositories
{
    public class IntroDbContext : DbContext
    {
        public IntroDbContext(DbContextOptions<IntroDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();
        }
    }
}
