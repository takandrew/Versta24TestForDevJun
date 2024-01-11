using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Versta24TestForDevJun.DAL.Entities;

namespace Versta24TestForDevJun.DAL.DataContext;

public partial class DeliveryContext : DbContext
{
    public DeliveryContext()
    {
    }

    public DeliveryContext(DbContextOptions<DeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Orders_pkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
