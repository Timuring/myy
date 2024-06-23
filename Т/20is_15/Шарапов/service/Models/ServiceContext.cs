﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace service.Models;

public partial class ServiceContext : DbContext
{
    public ServiceContext()
    {
    }

    public ServiceContext(DbContextOptions<ServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderuserlist> Orderuserlists { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userlist> Userlists { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=2004;database=service", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PRIMARY");

            entity
                .ToTable("order")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Amountdamage).HasColumnName("amountdamage");
            entity.Property(e => e.Carelement)
                .HasMaxLength(50)
                .HasColumnName("carelement");
            entity.Property(e => e.Datecreation).HasColumnName("datecreation");
            entity.Property(e => e.Details)
                .HasMaxLength(50)
                .HasColumnName("details");
            entity.Property(e => e.Liquids)
                .HasMaxLength(50)
                .HasColumnName("liquids");
            entity.Property(e => e.Orderstatus)
                .HasMaxLength(50)
                .HasColumnName("orderstatus");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(50)
                .HasColumnName("paymentstatus");
        });

        modelBuilder.Entity<Orderuserlist>(entity =>
        {
            entity.HasKey(e => e.Orderuserlistid).HasName("PRIMARY");

            entity
                .ToTable("orderuserlist")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Userid, "orderuserlist___fk");

            entity.HasIndex(e => e.Orderid, "orderuserlist___fk2");

            entity.Property(e => e.Orderuserlistid).HasColumnName("orderuserlistid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderuserlists)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderuserlist___fk2");

            entity.HasOne(d => d.User).WithMany(p => p.Orderuserlists)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderuserlist___fk");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Shiftid).HasName("PRIMARY");

            entity
                .ToTable("shift")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Shiftid).HasColumnName("shiftid");
            entity.Property(e => e.Dateend).HasColumnName("dateend");
            entity.Property(e => e.Datestart).HasColumnName("datestart");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity
                .ToTable("user")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Userroleid, "user___fk");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Middlename)
                .HasMaxLength(50)
                .HasColumnName("middlename");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Userroleid).HasColumnName("userroleid");

            entity.HasOne(d => d.Userrole).WithMany(p => p.Users)
                .HasForeignKey(d => d.Userroleid)
                .HasConstraintName("user___fk");
        });

        modelBuilder.Entity<Userlist>(entity =>
        {
            entity.HasKey(e => e.Userlistid).HasName("PRIMARY");

            entity
                .ToTable("userlist")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.Userid, "userlist___fk");

            entity.HasIndex(e => e.Shiftid, "userlist___fk2");

            entity.Property(e => e.Userlistid).HasColumnName("userlistid");
            entity.Property(e => e.Shiftid).HasColumnName("shiftid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Shift).WithMany(p => p.Userlists)
                .HasForeignKey(d => d.Shiftid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userlist___fk2");

            entity.HasOne(d => d.User).WithMany(p => p.Userlists)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userlist___fk");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.Userroleid).HasName("PRIMARY");

            entity
                .ToTable("userrole")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.Userroleid).HasColumnName("userroleid");
            entity.Property(e => e.Namerole)
                .HasMaxLength(50)
                .HasColumnName("namerole");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
