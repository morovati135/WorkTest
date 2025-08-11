using Domain.Models.Products;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace WorkTest.Infrastructure.Persistence
{
    public class WorkTestDbContext : DbContext
    {
        public WorkTestDbContext(DbContextOptions<WorkTestDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                
                entity.Property(u => u.Password)
                    .IsRequired();

                entity.HasMany(u => u.Products)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");
            });
        }
    }
}