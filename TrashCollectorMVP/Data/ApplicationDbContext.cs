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
        public DbSet<TemporaryPickupSuspension> TemporaryPickupSuspensions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Id = "57238b69-e427-4c16-a1b5-9622ffe269c8",
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "7ac58623-4d24-4301-ba6e-df7cb0e5b724"

            },
            new IdentityRole
            {
                Id = "b953561e-ff29-4a5f-aa9a-53c023680f13",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
                ConcurrencyStamp = "41376ad9-5200-46fb-9b91-c959c77c00a2"
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
