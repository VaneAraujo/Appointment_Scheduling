using System.Collections.Generic;
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

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Patient>().HasIndex(x => x.Name).IsUnique();

           

        }



    }

}
