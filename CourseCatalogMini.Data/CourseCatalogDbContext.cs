using CourseCatalogMini.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalogMini.Data
{
    public class CourseCatalogDbContext : DbContext
    {
        public CourseCatalogDbContext(
            DbContextOptions<CourseCatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(t => t.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(c => c.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(c => c.Description)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(c => c.Teacher)
                    .WithMany(t => t.Courses)
                    .HasForeignKey(c => c.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(c => c.Category)
                    .WithMany(c => c.Courses)
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.ToTable(t =>
                    t.HasCheckConstraint(
                        "CK_Courses_DurationHours",
                        "[DurationHours] > 0"));
            });
        }
    }
}