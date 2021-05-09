using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QACareManagement.DataModel
{
    public partial class QACareContext : DbContext
    {
        public QACareContext()
        {
        }

        public QACareContext(DbContextOptions<QACareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PromotionGift> PromotionGifts { get; set; }
        public virtual DbSet<PromotionGiftImageUpload> PromotionGiftImageUploads { get; set; }
        public virtual DbSet<PromotionGiftProduct> PromotionGiftProducts { get; set; }
        public virtual DbSet<RegisterOrder> RegisterOrders { get; set; }
        public virtual DbSet<RegisterOrderQrscanHistory> RegisterOrderQrscanHistories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagCustomer> TagCustomers { get; set; }
        public virtual DbSet<TagPromotionGift> TagPromotionGifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=QACareDBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.Role).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.Property(e => e.LatLong).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAddresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress_Customer");
            });

            modelBuilder.Entity<PromotionGift>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndRunRunning).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StarTimeAllowScanDaily).HasDefaultValueSql("('00:00:00')");

                entity.Property(e => e.StartDateRunning).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type).HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DealerCustomer)
                    .WithMany(p => p.PromotionGifts)
                    .HasForeignKey(d => d.DealerCustomerId)
                    .HasConstraintName("FK_PromotionGift_Customer");

                entity.HasOne(d => d.RegisterLocationCustomerAddress)
                    .WithMany(p => p.PromotionGifts)
                    .HasForeignKey(d => d.RegisterLocationCustomerAddressId)
                    .HasConstraintName("FK_PromotionGift_CustomerAddress");
            });

            modelBuilder.Entity<PromotionGiftImageUpload>(entity =>
            {
                entity.Property(e => e.FileLocation).IsUnicode(false);

                entity.HasOne(d => d.PromotionGift)
                    .WithMany(p => p.PromotionGiftImageUploads)
                    .HasForeignKey(d => d.PromotionGiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionGiftImageUpload_PromotionGift");
            });

            modelBuilder.Entity<PromotionGiftProduct>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PromotionGiftProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionGiftProduct_Product");

                entity.HasOne(d => d.PromotionGift)
                    .WithMany(p => p.PromotionGiftProducts)
                    .HasForeignKey(d => d.PromotionGiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionGiftProduct_PromotionGift");
            });

            modelBuilder.Entity<RegisterOrder>(entity =>
            {
                entity.Property(e => e.DateCreate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeCreate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CustomerDeliveryAddress)
                    .WithMany(p => p.RegisterOrders)
                    .HasForeignKey(d => d.CustomerDeliveryAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterOrder_CustomerAddress");

                entity.HasOne(d => d.PromotionGift)
                    .WithMany(p => p.RegisterOrders)
                    .HasForeignKey(d => d.PromotionGiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterOrder_PromotionGift");
            });

            modelBuilder.Entity<RegisterOrderQrscanHistory>(entity =>
            {
                entity.Property(e => e.DateScanned).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TimeScanned).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RegisterOrder)
                    .WithMany(p => p.RegisterOrderQrscanHistories)
                    .HasForeignKey(d => d.RegisterOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterOrderQRScanHistory_RegisterOrder");
            });

            modelBuilder.Entity<TagCustomer>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.CustomerId });

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TagCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagCustomer_Customer");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagCustomers)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagCustomer_Tags");
            });

            modelBuilder.Entity<TagPromotionGift>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.PromotionGiftId });

                entity.HasOne(d => d.PromotionGift)
                    .WithMany(p => p.TagPromotionGifts)
                    .HasForeignKey(d => d.PromotionGiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagPromotionGift_PromotionGift");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagPromotionGifts)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagPromotionGift_Tags");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
