
using CourseCatalogMini.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalogMini.Data;

public class CourseCatalogDbContext : DbContext
{
    public CourseCatalogDbContext(
        DbContextOptions<CourseCatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(c => c.Teacher)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Category)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            entity.ToTable(t =>
                t.HasCheckConstraint(
                    "CK_Courses_DurationHours",
                    "[DurationHours] > 0"));
        });
    }
}
