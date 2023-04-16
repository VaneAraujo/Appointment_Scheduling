using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using Appointment.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Scheduling> Schedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasIndex(x => x.user_id).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(d => d.role_id).IsUnique();
            modelBuilder.Entity<Scheduling>().HasIndex(d => d.order_id).IsUnique();


        }



    }

}
