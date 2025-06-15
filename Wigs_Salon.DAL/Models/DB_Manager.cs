using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wigs_Salon.DAL.Models;

public partial class DB_Manager : DbContext
{
    public DB_Manager()
    {
    }

    public DB_Manager(DbContextOptions<DB_Manager> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\Desktop\\Nitza Wigs\\Wigs_Salon.BL\\Wigs_Salon.DAL\\Data\\DB.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC245EDA609");

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Employees");

            entity.HasMany(d => d.Services).WithMany(p => p.Appointments)
                .UsingEntity<Dictionary<string, object>>(
                    "AppointmentService",
                    r => r.HasOne<Service>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AppointmentServices_Services"),
                    l => l.HasOne<Appointment>().WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AppointmentServices_Appointments"),
                    j =>
                    {
                        j.HasKey("AppointmentId", "ServiceId").HasName("PK__Appointm__329C47C22B1A59E3");
                        j.ToTable("AppointmentServices");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8CD3AE217");

            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11C36080F6");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.WorkDays).HasMaxLength(100);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB00A8C9B7A61");

            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
