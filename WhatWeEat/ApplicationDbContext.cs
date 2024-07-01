using System;
using Microsoft.EntityFrameworkCore;
using WhatWeEat.Models;

namespace WhatWeEat
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<EatRecord> EatRecords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Meals
            modelBuilder.Entity<Meal>()
                .HasIndex(m => m.Name).IsUnique();

            var apple = new Meal {Id = 1, Name = "Яблоко"};
            var bread = new Meal {Id = 2, Name = "Хлеб"};
            var eggs = new Meal {Id = 3, Name = "Яйца"};

            modelBuilder.Entity<Meal>().HasData(
                apple,
                bread,
                eggs
            );

            // Users
            var vasiliy = new User {Id = 1, Name = "Василий", Email = "vasiliy@mail.ru"};
            var petr = new User {Id = 2, Name = "Петр", Email = "petr@mail.ru"};
            modelBuilder.Entity<User>().HasData(
                vasiliy,
                petr
            );

            // Eat Records
            modelBuilder.Entity<EatRecord>().HasData(
                new EatRecord
                {
                    Id = 1,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("12:01 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 2,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("12:00 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 3,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("11:59 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 4,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("11:58 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 5,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("11:57 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 6,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("11:56 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 7,
                    MealId = apple.Id,
                    Timestamp = DateTime.Parse("11:55 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 8,
                    MealId = bread.Id,
                    Timestamp = DateTime.Parse("12:25 17/05/2018"),
                    UserId = vasiliy.Id
                },
                new EatRecord
                {
                    Id = 9,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:07 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 10,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:06 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 11,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:05 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 12,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:04 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 13,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:03 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 14,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:02 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 15,
                    MealId = eggs.Id,
                    Timestamp = DateTime.Parse("17:01 15/05/2018"),
                    UserId = petr.Id
                },
                new EatRecord
                {
                    Id = 16,
                    MealId = bread.Id,
                    Timestamp = DateTime.Parse("17:00 15/05/2015"),
                    UserId = petr.Id
                }
            );
        }
    }
}