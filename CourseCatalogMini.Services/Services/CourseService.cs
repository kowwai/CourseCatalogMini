using Microsoft.EntityFrameworkCore;
using CourseCatalogMini.Data;
using CourseCatalogMini.Data.Entities;
using CourseCatalogMini.Services.DTOs.Courses;
using CourseCatalogMini.Services.Interfaces;

namespace CourseCatalogMini.Services.Services;

public class CourseService : ICourseService
{
    private readonly CourseCatalogDbContext _context;

    public CourseService(CourseCatalogDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseListDto>> GetAll(
        string? search,
        string? category)
    {
        var query = _context.Courses.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();

            query = query.Where(c =>
                c.Name.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(c =>
                c.Category == category);
        }

        return await query
            .OrderBy(c => c.Name)
            .Select(c => new CourseListDto
            {
                Id = c.Id,
                Name = c.Name,
                Teacher = c.Teacher,
                Category = c.Category,
                DurationHours = c.DurationHours,
                Description = c.Description
            })
            .ToListAsync();
    }

    public void AddCourse(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
    }
}
