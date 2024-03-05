using EcommerceNetBlazor.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceNetBlazor.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(sd => sd.Id);
                entity.Property(sd => sd.Total).HasColumnType("decimal(10, 2)");
                entity.HasOne(sd => sd.Product).WithMany(p => p.SalesDetails)
                    .HasForeignKey(sd => sd.ProductId);

                entity.HasOne(sd => sd.Sale).WithMany(s => s.SalesDetails)
                    .HasForeignKey(sd => sd.SaleId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(p => p.Image).IsUnicode(false);
                entity.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(p => p.Price).HasColumnType("decimal(10, 2)");
                entity.Property(p => p.PriceOffer).HasColumnType("decimal(10, 2)");

                entity.HasOne(p => p.Category).WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
              
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Total).HasColumnType("decimal(10, 2)");

                entity.HasOne(s => s.User).WithMany(u => u.Sales)
                    .HasForeignKey(s => s.UserId);
            });
        }
    

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SalesDetails { get; set; }
        public DbSet<User> Users { get; set; }


    }
}