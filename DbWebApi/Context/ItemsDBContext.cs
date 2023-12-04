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

        public virtual DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trips");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
