﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SolarMP.Models
{
    public partial class solarMPContext : DbContext
    {
        public solarMPContext()
        {
        }

        public solarMPContext(DbContextOptions<solarMPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acceptance> Acceptance { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bracket> Bracket { get; set; }
        public virtual DbSet<ConstructionContract> ConstructionContract { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageProduct> PackageProduct { get; set; }
        public virtual DbSet<PaymentProcess> PaymentProcess { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductWarrantyReport> ProductWarrantyReport { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<WarrantyReport> WarrantyReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // server
                optionsBuilder.UseSqlServer("Data Source=solarcaps.database.windows.net;Initial Catalog=solarMP;Persist Security Info=True;User ID=solar;Password=S@lar123456789");
                // local
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-8LC85HGU\\SQLEXPRESS;Initial Catalog=solarMP;Persist Security Info=True;User ID=sa;Password=12");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acceptance>(entity =>
            {
                entity.HasOne(d => d.ConstructionContract)
                    .WithMany(p => p.Acceptance)
                    .HasForeignKey(d => d.ConstructionContractId)
                    .HasConstraintName("FK__Acceptanc__const__5165187F");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(e => e.Username, "User")
                    .IsUnique()
                    .HasFilter("([username] IS NOT NULL)");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique()
                    .HasFilter("([email] IS NOT NULL)");

                entity.HasIndex(e => e.Phone, "phone")
                    .IsUnique()
                    .HasFilter("([phone] IS NOT NULL)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<ConstructionContract>(entity =>
            {
                entity.HasOne(d => d.Bracket)
                    .WithMany(p => p.ConstructionContract)
                    .HasForeignKey(d => d.BracketId)
                    .HasConstraintName("FK__Construct__brack__5629CD9C");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ConstructionContractCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_ConstructionContract_Account1");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.ConstructionContract)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__Construct__packa__5441852A");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ConstructionContractStaff)
                    .HasForeignKey(d => d.Staffid)
                    .HasConstraintName("FK_ConstructionContract_Account");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasOne(d => d.Bracket)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.BracketId)
                    .HasConstraintName("FK_Image_Bracket");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ProcessId)
                    .HasConstraintName("FK_Image_Process");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Image_Product");

                entity.HasOne(d => d.WarrantyReport)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.WarrantyReportId)
                    .HasConstraintName("FK_Image_WarrantyReport");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Package__promoti__5DCAEF64");
            });

            modelBuilder.Entity<PackageProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.PackageId });

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageProduct)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageProduct_Package");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PackageProduct)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackageProduct_Product");
            });

            modelBuilder.Entity<PaymentProcess>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__PaymentP__AF26EBEEE740B76B");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PaymentProcess)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentProcess_Account");

                entity.HasOne(d => d.ConstructionContract)
                    .WithMany(p => p.PaymentProcess)
                    .HasForeignKey(d => d.ConstructionContractId)
                    .HasConstraintName("FK__PaymentPr__const__5EBF139D");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.Process)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Process_ConstructionContract");
            });

            modelBuilder.Entity<ProductWarrantyReport>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.WarrantyId });

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductWarrantyReport)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductWa__produ__6B24EA82");

                entity.HasOne(d => d.Warranty)
                    .WithMany(p => p.ProductWarrantyReport)
                    .HasForeignKey(d => d.WarrantyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductWa__warra__628FA481");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Account");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Package");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Survey)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Survey_Account");
            });

            modelBuilder.Entity<WarrantyReport>(entity =>
            {
                entity.HasKey(e => e.WarrantyId)
                    .HasName("PK__Warranty__05ACB4E9DB04664C");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.WarrantyReport)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_WarrantyReport_Account");

                entity.HasOne(d => d.Contract)
                    .WithMany(p => p.WarrantyReport)
                    .HasForeignKey(d => d.ContractId)
                    .HasConstraintName("FK_WarrantyReport_ConstructionContract");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}