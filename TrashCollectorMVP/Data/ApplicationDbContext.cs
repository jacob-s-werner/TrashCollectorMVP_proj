using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrashCollectorMVP.Models;

namespace TrashCollectorMVP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WeeklyPickupDay> WeeklyPickupDays { get; set; }
        public DbSet<OneTimePickup> OneTimePickups { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            },
            new IdentityRole
            {
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            }
            );
            builder.Entity<WeeklyPickupDay>()
                .HasData(
            new WeeklyPickupDay
            {
                Id = 1,
                Day = "Sunday"
            },
            new WeeklyPickupDay
            {
                Id = 2,
                Day = "Monday"
            },
            new WeeklyPickupDay
            {
                Id = 3,
                Day = "Tuesday"
            },
            new WeeklyPickupDay
            {
                Id = 4,
                Day = "Wednesday"
            },
            new WeeklyPickupDay
            {
                Id = 5,
                Day = "Thursday"
            },
            new WeeklyPickupDay
            {
                Id = 6,
                Day = "Friday"
            },
            new WeeklyPickupDay
            {
                Id = 7,
                Day = "Saturday"
            });
        }
    }
}
