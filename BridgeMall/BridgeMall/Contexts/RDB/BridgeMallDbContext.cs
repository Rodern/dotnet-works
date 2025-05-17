using System;
using System.Collections.Generic;
using BridgeMall.Models.Relational;
using Microsoft.EntityFrameworkCore;

namespace BridgeMall.Contexts.RDB;

public partial class BridgeMallDbContext : DbContext
{
    public BridgeMallDbContext()
    {
    }

    public BridgeMallDbContext(DbContextOptions<BridgeMallDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Password> Passwords { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        if (optionsBuilder != null) optionsBuilder.UseMySQL("server=localhost;port=3306;database=bridge-mall_db;user=root;password=");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("categoryId");
            entity.Property(e => e.Code)
                .HasMaxLength(6)
                .HasColumnName("code");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Password>(entity =>
        {
            entity.HasKey(e => e.PasswordId).HasName("PRIMARY");

            entity.ToTable("password");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.PasswordId)
                .HasColumnType("int(11)")
                .HasColumnName("passwordId");
            entity.Property(e => e.Hashed)
                .HasMaxLength(1000)
                .HasColumnName("hashed");
            entity.Property(e => e.LastChanged)
                .HasColumnType("datetime")
                .HasColumnName("last_changed");
            entity.Property(e => e.PastPasswords)
                .HasComment("This field, takes a an object like \r\n\r\n[{\r\n \"hashed\" \"string\",\r\n \"salt\" : byte[]\r\n}\r\n]")
                .HasColumnName("past_passwords");
            entity.Property(e => e.Salt)
                .HasMaxLength(128)
                .HasColumnName("salt");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Passwords)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("password_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "categoryId");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("productId");
            entity.Property(e => e.CategoryId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("categoryId");
            entity.Property(e => e.Code)
                .HasColumnType("int(6)")
                .HasColumnName("code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("int(11)")
                .HasColumnName("image");
            entity.Property(e => e.InStock)
                .HasColumnType("int(11)")
                .HasColumnName("in_stock");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("int(11)")
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasColumnType("enum('User','Admin','Dev')")
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.UserTokenId).HasName("PRIMARY");

            entity.ToTable("user_token");

            entity.HasIndex(e => e.UserId, "userId").IsUnique();

            entity.Property(e => e.UserTokenId)
                .HasColumnType("int(11)")
                .HasColumnName("user_tokenId");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("expiry_date");
            entity.Property(e => e.LastModified)
                .HasColumnType("datetime")
                .HasColumnName("last_modified");
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .HasColumnName("token");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithOne(p => p.UserToken)
                .HasForeignKey<UserToken>(d => d.UserId)
                .HasConstraintName("user_token_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
