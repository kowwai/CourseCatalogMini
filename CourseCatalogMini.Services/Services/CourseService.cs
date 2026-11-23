using Microsoft.EntityFrameworkCore;
using CourseCatalogMini.Data;
using CourseCatalogMini.Data.Entities;
using CourseCatalogMini.Services.DTOs.Courses;
using CourseCatalogMini.Services.Interfaces;

namespace CourseCatalogMini.Services.Services
{
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
                category = category.Trim();

                query = query.Where(c =>
                    c.Category.Name == category);
            }

            return await query
                .OrderBy(c => c.Name)
                .Select(c => new CourseListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Teacher = c.Teacher.Name,
                    Category = c.Category.Name,
                    DurationHours = c.DurationHours,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public void AddCourse(CourseCreateDto model)
        {
            string teacherName = model.Teacher.Trim();
            string categoryName = model.Category.Trim();

            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Name == teacherName);

            if (teacher == null)
            {
                teacher = new Teacher
                {
                    Name = teacherName
                };
            }

            var category = _context.Categories
                .FirstOrDefault(c => c.Name == categoryName);

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName
                };
            }

            var course = new Course
            {
                Name = model.Name.Trim(),
                Teacher = teacher,
                Category = category,
                DurationHours = model.DurationHours,
                Description = model.Description.Trim()
            };

            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}