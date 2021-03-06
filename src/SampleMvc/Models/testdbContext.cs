﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleMvc.Models
{
    public partial class testdbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SJ8PH5T\SQLEXPRESS;Database=testdb;Trusted_Connection=True");
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

                entity.Property(e => e.PrefectureId).HasColumnName("prefecture_id");

                entity.HasOne(d => d.Prefecture)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.PrefectureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_person_prefecture");
            });

            modelBuilder.Entity<Prefecture>(entity =>
            {
                entity.ToTable("prefecture");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(10)");
            });
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Prefecture> Prefecture { get; set; }
    }
}