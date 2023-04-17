using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using Appointment.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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
            modelBuilder.Entity<User>().HasMany(user => user.schedules).WithOne().HasForeignKey(schedule => schedule.patient_id); // Relacion uno a muchos de usuarios con rol paciente a la tabla Schedules
            modelBuilder.Entity<User>().HasMany(user => user.schedules).WithOne().HasForeignKey(schedule => schedule.doctor_id); // Relacion uno a muchos de usuarios con rol médico a la tabla Schedules

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users);
        }



    }

}
