using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL
{
    public partial class ProductReviewContext : DbContext
    {
        public ProductReviewContext(DbContextOptions<ProductReviewContext> options):base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
          //  optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=ProductReview;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A2BE753C08E");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Categori__8517B2E05E97549D")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B894F5FC1F");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(100);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__Images__7516F4EC2CFC87C6");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");

                entity.Property(e => e.ImageDescription).IsRequired();

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Images__ProductI__29572725");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6ED8703E34F");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__267ABA7A");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Reviews__74BC79AE0EE5BE3A");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Reviews__Custome__2F10007B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Reviews__Product__2E1BDC42");
            });
        }
    }
}