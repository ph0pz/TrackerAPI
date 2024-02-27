using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrackerData;

public partial class TrackerDbContext : DbContext
{
    public TrackerDbContext()
    {
    }

    public TrackerDbContext(DbContextOptions<TrackerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryType> CategoryTypes { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BE3B03EC7");

            entity.Property(e => e.CategoryColor)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("PK__Category__7B30E7A3DDE6FE7D");

            entity.Property(e => e.CategoryTypeName)
                .HasMaxLength(255)
                .IsUnicode(false);


        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__Notes__EACE355FDC2BFD9A");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notes__UserId__787EE5A0");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Persons__1788CC4C9554D924");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NickName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A6B79628529");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CategoryTypeId)
                .HasConstraintName("FK__Transacti__Categ__02084FDA");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .HasConstraintName("FK__Transacti__Trans__01142BA1");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__02FC7413");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
               .HasForeignKey(d => d.CategoryId)
               .HasConstraintName("FK_Transactions_Categories");


        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeId).HasName("PK__Transact__20266D0B44DDB6FF");

            entity.Property(e => e.TransactionTypeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
