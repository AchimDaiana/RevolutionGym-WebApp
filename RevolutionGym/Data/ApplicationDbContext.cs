using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RevolutionGym.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevolutionGym.Data
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
