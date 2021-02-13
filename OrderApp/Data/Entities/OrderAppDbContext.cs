using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OrderApp.Data.Entities
{
    public partial class OrderAppDbContext : DbContext
    {
        public OrderAppDbContext()
        {
        }

        public OrderAppDbContext(DbContextOptions<OrderAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=orderapp-db", x => x.ServerVersion("10.5.8-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("business");

                entity.HasIndex(e => e.BusinessID)
                    .HasName("BusinessID")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Name")
                    .IsUnique();

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessID)
                    .IsRequired()
                    .HasColumnName("BusinessID")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("int(11)");

                entity.Property(e => e.Meta).HasColumnType("blob");

                entity.Property(e => e.ModifiedDate).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.HasIndex(e => e.BusinessId)
                    .HasName("FK_Location_BusinessID");

                entity.HasIndex(e => e.LocationId)
                    .HasName("LocationID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessId)
                    .IsRequired()
                    .HasColumnName("BusinessID")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("int(11)");

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasColumnName("LocationID")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Meta).HasColumnType("blob");

                entity.Property(e => e.ModifiedDate).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Location)
                    .HasPrincipalKey(p => p.BusinessID)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_BusinessID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.BusinessId)
                    .HasName("FK_Product_BusinessID");

                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessId)
                    .IsRequired()
                    .HasColumnName("BusinessID")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("int(11)");

                entity.Property(e => e.Meta).HasColumnType("blob");

                entity.Property(e => e.ModifiedDate).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.Product)
                    .HasPrincipalKey(p => p.BusinessID)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_BusinessID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
