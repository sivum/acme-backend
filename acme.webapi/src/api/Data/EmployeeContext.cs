using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public class EmployeeContext:DbContext
    {
       
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            :base(options)
        {

        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");
                entity.HasKey(e => e.PersonId);
                entity.Property(e => e.LastName).IsRequired()
                    .HasMaxLength(55);
                entity.Property(e => e.FirstName).IsRequired()
                   .HasMaxLength(55);
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.HasKey(e => e.EmployeeId);
                entity.Property(e => e.EmployeeNum).IsRequired()
                    .HasMaxLength(25);
                entity.Property(e => e.EmployedDate).IsRequired()
                   .HasMaxLength(55);
                entity.HasOne(a => a.Person)
                .WithOne(b => b.Employee)
                 .HasConstraintName("FK_Employee_Person");
            });

        }
    }
}
