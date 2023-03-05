﻿using Microsoft.EntityFrameworkCore;

namespace AllergyCalendarAPI.Entities;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Symptom> Symptoms { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .Property(b => b.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<User>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<User>()
            .Property(b => b.PasswordHash)
            .IsRequired();

        builder.Entity<Day>()
            .Property(b => b.Date)
            .IsRequired();

        builder.Entity<Day>()
            .HasIndex(b => b.Date)
            .IsUnique();

        builder.Entity<Day>()
            .Property(b => b.MedicineId)
            .IsRequired();

        builder.Entity<Day>()
            .Property(b => b.UserId)
            .IsRequired();

        builder.Entity<Medicine>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<Medicine>()
            .Property(b => b.UserId)
            .IsRequired();

        builder.Entity<Symptom>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<Symptom>()
            .Property(b => b.UserId)
            .IsRequired();
    }
}