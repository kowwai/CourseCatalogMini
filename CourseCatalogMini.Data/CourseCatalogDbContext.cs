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
    }
}