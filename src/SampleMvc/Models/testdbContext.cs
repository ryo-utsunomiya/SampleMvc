using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleMvc.Models
{
    public partial class testdbContext : DbContext
    {
        public testdbContext(DbContextOptions<testdbContext> options) : base(options)
        {
            // Do nothing
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Do nothing
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");
            });
        }

        public virtual DbSet<Person> Person { get; set; }
    }
}