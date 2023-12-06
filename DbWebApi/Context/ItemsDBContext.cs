using System;
using System.Collections.Generic;
using DbWebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbWebApi.Context
{
    public partial class ItemsDBContext : DbContext
    {
        public ItemsDBContext()
        {
        }

        public ItemsDBContext(DbContextOptions<ItemsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employe> Employes { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("employes");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("managers");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trips");

                entity.Property(e => e.EmployesId).HasColumnName("Employes_id");

                entity.HasOne(d => d.Employes)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.EmployesId)
                    .HasConstraintName("trips_employes_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
